using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public Sprite[] Backgrounds;
    public GameObject[] CharacterPrefabs;
    public GameObject[] DinningTablePrefabs;
    public AnimationController animationController;
    public GameObject Popup;
    public Image Background;
    private int currentScore = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        // Load the background based on the current level
        Background.sprite = Backgrounds[LevelSelectionMenuManager.CurrentLevel];

        InitiateCharacters();

        // If the current level is the dinning table level
        if (LevelSelectionMenuManager.CurrentLevel == 4) InitiateDinningTable();
    }

    // Initiate the characters (mother/father and daughter/son)
    private void InitiateCharacters()
    {
        // Initiate parent based on the player's choice
        GameObject parent = Instantiate(CharacterPrefabs[PlayerPrefs.GetString("Character").Equals("Mother") ? 0 : 1]);

        // Levels 1, 3, 5 (girl); Levels 2, 4 (boy) 
        GameObject adolescent = Instantiate(CharacterPrefabs[LevelSelectionMenuManager.CurrentLevel % 2 == 0 ? 2 : 3]);

        // Set animation controllers
        animationController.ParentAnimator = parent.GetComponent<Animator>();
        animationController.AdolescentAnimator = adolescent.GetComponent<Animator>();
    }

    // Special case for Level 5
    private void InitiateDinningTable()
    {
        // Initiate the dinning table
        foreach (GameObject prefab in DinningTablePrefabs)
        {
            Instantiate(prefab);
        }
    }

    // Updates the score after player's choice
    public void UpdateScore(int score)
    {
        currentScore += score;
    }

    // Unlock a trophie based on the player's choice
    public void UnlockTrophie(string trophieId)
    {
        // If the trophie is already unlocked return
        if (PlayerPrefs.GetString("Trophie" + trophieId, "Locked").Equals("Unlocked")) return;

        // Unlock the trophie
        PlayerPrefs.SetString("Trophie" + trophieId, "Unlocked");

        DisplayPopup(trophieId);
    }

    private void DisplayPopup(string trophieId)
    {
        SoundFXManager.Instance.PlayNewAchievementSound();

        Popup.SetActive(true);
        Popup.GetComponent<Animator>().Play("Achievement Popup");

        // Add event listener to the popup button (shows the strategy panel)
        Popup.GetComponent<Button>().onClick.AddListener(() =>
        {
            Popup.GetComponent<AchievementsMenuManager>().ShowStrategyPanel(int.Parse(trophieId));
        });

        StartCoroutine(ClosePopup());
    }

    // Close the popup after 3 seconds
    private IEnumerator ClosePopup()
    {
        yield return new WaitForSeconds(4);
        Popup.SetActive(false);
    }

    private void UnlockNextLevel()
    {
        // If the current level is the last unlocked level
        if (LevelSelectionMenuManager.CurrentLevel == LevelSelectionMenuManager.UnlockedLevels - 1)
        {
            // If the player has finished the game
            if (LevelSelectionMenuManager.CurrentLevel == 4) PlayerPrefs.SetString("FinishedGame", "Yes");
            
            LevelSelectionMenuManager.UnlockedLevels++;
            PlayerPrefs.SetInt("UnlockedLevels", LevelSelectionMenuManager.UnlockedLevels);
        }
    }

    private readonly Dictionary<int, int> levelMaxScores = new Dictionary<int, int> // Level index, max score
    {
        { 0, 10 },
        { 1, 20 },
        { 2, 28 },
        { 3, 28 },
        { 4, 46 }
    };

    // Calculate the progress of the player (in percentage)
    private float CalculateProgress()
    {
        if (currentScore < 0) currentScore = 0;
        int maxScore = levelMaxScores[LevelSelectionMenuManager.CurrentLevel];
        return (float)currentScore / maxScore * 100;
    }

    private void SetLevelProgress(float progress)
    {
        // If the player has earned a higher score than previously
        if (progress > PlayerPrefs.GetFloat("Score" + LevelSelectionMenuManager.CurrentLevel.ToString(), 0))
        {
            PlayerPrefs.SetFloat("Score" + LevelSelectionMenuManager.CurrentLevel.ToString(), progress);
        }
    }

    private void SetLevelStars(float progress)
    {
        // Calculate the number of stars earned
        int stars = progress >= 80 ? 3 : progress >= 50 ? 2 : progress >= 30 ? 1 : 0;

        // If the player has earned more stars than previously
        if (stars > PlayerPrefs.GetInt("Stars" + LevelSelectionMenuManager.CurrentLevel.ToString(), 0))
        {
            PlayerPrefs.SetInt("Stars" + LevelSelectionMenuManager.CurrentLevel.ToString(), stars);
        }
    }

    public void CompleteLevel()
    {
        float progress = CalculateProgress();
        SetLevelProgress(progress);
        SetLevelStars(progress);

        UnlockNextLevel();

        SceneManager.LoadScene("Level Selector");
    }

    public void ExitLevel()
    {
        SceneManager.LoadScene("Level Selector");
    }
}
