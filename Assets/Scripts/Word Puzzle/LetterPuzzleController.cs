using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class LetterPuzzleController : MonoBehaviour
{
    public DialogueManager dialogueManager;
    private string word;
    private List<string> clues;
    private int clueShownIndex = 0;

    // UI elements
    public GameObject LetterPrefab;
    public GameObject LetterSlotPrefab;
    public GameObject LetterContainer;
    public GameObject LetterSlotContainer;
    public TextMeshProUGUI ClueText;
    [SerializeField] private Canvas canvas;


    /// Starts the letter puzzle by instantiating the letter slots and letters for the word.
    public void StartPuzzle(string word, List<string> clues)
    {
        this.word = word;

        ExtractClues(clues);
        InstantiateLetters();
        InstantiateLetterSlots();
    }

    private void StopPuzzle()
    {
        // Destroy all the letters and letter slots in the puzzle.
        DestroyChildren(LetterContainer.transform);
        DestroyChildren(LetterSlotContainer.transform);

        // Reset puzzle variables
        transform.gameObject.SetActive(false);
        dialogueManager.IsPlayingPuzzle = false;
        clueShownIndex = 0;
        clues.Clear();
        ClueText.text = "";

        // Display the next sentence in the dialog.
        dialogueManager.DisplayNextSentence();
    }

    // If all the letters are in the correct slots, stop the puzzle.
    public void CheckPuzzleComplete()
    {
        if (LetterContainer.transform.childCount == 0)
        {
            foreach (Transform slot in LetterSlotContainer.transform)
            {
                if (slot.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text != slot.GetComponent<LetterSlotController>().Letter)
                {
                    return;
                }
            }
            StopPuzzle();
        }
    }

    public void ShowClue()
    {
        if (clueShownIndex < clues.Count)
        {
            ClueText.text = clues[clueShownIndex];
            clueShownIndex++;

            // Subtract a point from the player's score.
            LevelManager.Instance.UpdateScore(-1);
        }
    }

    // Extracts the clues from the tags in the ink story.
    private void ExtractClues(List<string> tags)
    {

        clues = new List<string>();

        foreach (string t in tags)
        {
            string prefix = t.Split(": ")[0];

            if (prefix.ToLower() == "clue")
            {
                clues.Add(t.Split(": ")[1]);
            }
        }
    }

    // Instantiate a letter for each letter in the word (shuffled).
    private void InstantiateLetters()
    {
        // Shuffle the letters in the word.
        char[] shuffledLetters = Shuffle(word.ToCharArray());

        for (int i = 0; i < shuffledLetters.Length; i++)
        {
            GameObject letter = Instantiate(LetterPrefab, LetterContainer.transform);
            
            letter.GetComponent<LetterController>().Canvas = canvas;
            letter.GetComponent<LetterController>().LetterContainer = LetterContainer;
            letter.GetComponent<LetterController>().SetLetter(shuffledLetters[i].ToString().ToUpper());
        }
    }

    // Instantiate a letter slot for each letter in the word (ordered).
    private void InstantiateLetterSlots()
    {
        for (int i = 0; i < word.Length; i++)
        {
            GameObject letterSlot = Instantiate(LetterSlotPrefab, LetterSlotContainer.transform);

            letterSlot.GetComponent<LetterSlotController>().PuzzleController = this;
            letterSlot.GetComponent<LetterSlotController>().Letter = word[i].ToString().ToUpper();
        }
    }

    ///  Shuffles the elements of a char array.
    private static char[] Shuffle(char[] letters)
    {
        char[] original = (char[])letters.Clone();
        System.Random rng = new System.Random();
        int n = letters.Length;

        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            var value = letters[k];
            letters[k] = letters[n];
            letters[n] = value;
        }

        return Enumerable.SequenceEqual(letters, original) ? Shuffle(letters) : letters;
    }

    /// Destroys all the children of a given parent transform.
    private void DestroyChildren(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }
    }
}