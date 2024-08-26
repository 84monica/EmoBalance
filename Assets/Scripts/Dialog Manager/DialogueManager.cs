using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// Manages the dialog system in the game.
public class DialogueManager : MonoBehaviour
{
    // Ink variables
    public TextAsset[] InkAssets;
    private static Choice choiceSelected;
    private bool isMakingDecision = false;
    private bool isWrittingSentence = false;
    private static Story story;

    // Animation variables
    public AnimationController AnimationController;

    // Dialog Box UI elements
    public Image DialogueBubble;
    public Sprite[] DialogueBubbleSprites;
    public TextMeshProUGUI DialogueText;

    // Options Panel UI elements
    public GameObject OptionPanel;
    public GameObject OptionButtonPrefab;

    // Letter Puzzle elements
    public GameObject LetterPuzzle;
    public bool IsPlayingPuzzle = false;


    /// Initializes the dialog system by creating a new Story instance.
    private void Start()
    {
        story = new Story(InkAssets[LevelSelectionMenuManager.CurrentLevel].text);
        DisplayNextSentence();
    }

    private void Update()
    {
        // If the player taps the screen and the letter puzzle is not active
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !IsPlayingPuzzle && !isMakingDecision)
        {
            // If the sentence is still being typed out, skip to the end of the sentence.
            if (isWrittingSentence)
            {
                StopAllCoroutines();
                DialogueText.text = story.currentText;
                isWrittingSentence = false;
                SoundFXManager.Instance.StopCharacterSpeakingSound();
            }

            // If the story can continue, display the next sentence.
            else if (story.canContinue)
            {
                DisplayNextSentence();
            }

            // If the story has choices, display the choices.
            else if (story.currentChoices.Count != 0)
            {
                StartCoroutine(ShowChoices());
            }

            // End the level if there are no more lines to display.
            else if (!story.canContinue && story.currentChoices.Count == 0)
            {
                FinishLevel();
            }
        }
    }

    private void FinishLevel()
    {
        LevelManager.Instance.CompleteLevel();
    }

    public void DisplayNextSentence()
    {
        string sentence = story.Continue();
        AnimationController.StopPreviousTalkingAnimations();
        ParseTags();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    /// Types out the sentence letter by letter.
    /// <param name="sentence">The sentence to be typed out.</param>
    private IEnumerator TypeSentence(string sentence)
    {
        DialogueText.text = "";
        isWrittingSentence = true;
        SoundFXManager.Instance.PlayCharacterSpeakingSound();

        foreach (char letter in sentence.ToCharArray())
        {
            DialogueText.text += letter;
            yield return null;
        }
        
        isWrittingSentence = false;
        SoundFXManager.Instance.StopCharacterSpeakingSound();
    }

    /// Advances the story based on the player's choice.
    private void AdvanceFromDecision()
    {
        ClearOptionsPanel();

        choiceSelected = null;
        isMakingDecision = false;

        DisplayNextSentence();
    }

    private void ClearOptionsPanel()
    {
        // Hide the options panel.
        OptionPanel.SetActive(false);

        // Reset the scrollbar to the top.
        OptionPanel.transform.GetComponent<ScrollRect>().verticalNormalizedPosition = 1;

        // Destroy all the buttons in the options panel.
        Transform temp = OptionPanel.transform.GetChild(1);
        for (int i = 0; i < temp.childCount; i++)
        {
            Destroy(temp.GetChild(i).gameObject);
        }
    }

    /// Displays the choices available to the player.
    private IEnumerator ShowChoices()
    {
        isMakingDecision = true;

        OptionPanel.SetActive(true);

        // Create a new button for each choice.
        List<Choice> choices = story.currentChoices;
        for (int i = 0; i < choices.Count; i++)
        {
            CreateChoiceButton(choices[i]);
        }

        // Wait until the player makes a choice.
        yield return new WaitUntil(() => { return choiceSelected != null; });

        // Advance the story based on the player's choice.
        AdvanceFromDecision();
    }

    /// Creates a button for the choice.
    private void CreateChoiceButton(Choice choice)
    {
        GameObject temp = Instantiate(OptionButtonPrefab, OptionPanel.transform.GetChild(1));
        temp.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = choice.text;
        temp.AddComponent<Selectable>();
        temp.GetComponent<Selectable>().element = choice;
        temp.GetComponent<Button>().onClick.AddListener(() =>
        {
            temp.GetComponent<Selectable>().Decide();
            
        });
    }

    // Sets the choice selected by the player.
    public static void SetDecision(object element)
    {
        choiceSelected = (Choice)element;
        story.ChooseChoiceIndex(choiceSelected.index);
    }

    /// Parses the tags in the current line of dialog.
    private void ParseTags()
    {
        List<string> tags = story.currentTags;
        foreach (string t in tags)
        {
            string prefix = t.Split(' ')[0];
            string param = t.Split(' ')[1];

            switch (prefix.ToLower())
            {
                case "anim":
                    switch (param)
                    {
                        case "parent" or "adolescent":
                            StartCharacterAnimation(param, t.Split(' ')[2]);
                            break;
                        case "brother":
                            SpawnBrother();
                            break;
                        case "think":
                            SetTextBox(2, new RectOffset(50, 50, 150, 50), FontStyles.Italic);
                            break;
                        case "narrator":
                            SetTextBox(3, new RectOffset(50, 50, 50, 50), FontStyles.Italic);
                            break;
                        case "feedback":
                            SetTextBox(4, new RectOffset(100, 100, 100, 100), FontStyles.Normal);
                            break;
                    }
                    break;

                case "puzzle":
                    DisplayPuzzle(param, tags);
                    return;
                case "score":
                    LevelManager.Instance.UpdateScore(int.Parse(param));
                    break;
                case "strategy":
                    LevelManager.Instance.UnlockTrophie(param);
                    break;
            }
        }
    }

    private void SpawnBrother()
    {
        // Special case for the dinning scene (Level 5)
        GameObject brother = Instantiate(LevelManager.Instance.CharacterPrefabs[3]);
        brother.GetComponent<Transform>().position = new Vector3(0.05f, -3.6f, 14.69f);
        brother.GetComponent<Transform>().rotation = Quaternion.Euler(0, 156.42f, 0);
        brother.GetComponent<Animator>().SetBool("excited", true);
    }

    private void StartCharacterAnimation(string character, string animation)
    {
        DisplayDialogBox(character, animation);

        // Start the animation for the character.
        AnimationController.StartCharacterAnimation(character, animation);
    }

    private void DisplayDialogBox(string character, string animation)
    {
        // If the character is talking, yelling, or arguing display the dialog box.
        if (animation == "talking" || animation == "yelling" || animation == "arguing")
        {
            int textBoxIndex = character == "parent" ? 0 : 1;
            SetTextBox(textBoxIndex, new RectOffset(50, 50, 300, 50), FontStyles.Normal);
        }
    }

    /// Sets the dialog box sprite, padding, and font style.
    private void SetTextBox(int spriteIndex, RectOffset padding, FontStyles fontStyle)
    {
        DialogueBubble.sprite = DialogueBubbleSprites[spriteIndex];
        DialogueBubble.GetComponent<HorizontalLayoutGroup>().padding = padding;
        DialogueText.fontStyle = fontStyle;
    }

    /// Starts the word puzzle with the given word and clues.
    private void DisplayPuzzle(string word, List<string> clues)
    {
        SetTextBox(4, new RectOffset(100, 100, 100, 100), FontStyles.Normal);
        IsPlayingPuzzle = true;
        LetterPuzzle.SetActive(true);
        LetterPuzzle.GetComponent<LetterPuzzleController>().StartPuzzle(word, clues);
    }
}
