using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionMenuManager : MonoBehaviour
{
    public LevelObject[] levels;
    public static int UnlockedLevels;
    public static int CurrentLevel = 0;
    public Button LeftButton;
    public Button RightButton;
    public GameObject FinishedGamePanel;

    void Start()
    {
        UnlockLevels();

        // If the player has finished the game, show the Finished Game panel.
        if (PlayerPrefs.GetString("FinishedGame", "No") == "Yes")
        {
            FinishedGamePanel.SetActive(true);
            SoundFXManager.Instance.PlayFinishedGameSound();
            PlayerPrefs.SetString("FinishedGame", "No");
        }

        else
        {
            ManageArrowButtons();
            ShowCurrentLevel();
        }
    }


    // Unlocks the levels based on the number of unlocked levels stored in PlayerPrefs.
    private void UnlockLevels()
    {
        UnlockedLevels = PlayerPrefs.GetInt("UnlockedLevels", 1);

        for (int i = 0; i < levels.Length; i++)
        {
            if (i < UnlockedLevels)
            {
                levels[i].Unlock(i);
            }
        }
    }

    // Shows the current level by setting its game object to active.
    private void ShowCurrentLevel()
    {
        levels[CurrentLevel].gameObject.SetActive(true);
    }

    // Hides the current level by deactivating its game object.
    private void HideCurrentLevel()
    {
        levels[CurrentLevel].gameObject.SetActive(false);
    }

    public void OnClickStartLevel()
    {
        SceneManager.LoadScene("Level");
    }

    public void OnClickLeft()
    {
        HideCurrentLevel();
        CurrentLevel--;
        ManageArrowButtons();
        ShowCurrentLevel();
    }

    public void OnClickRight()
    {
        HideCurrentLevel();
        CurrentLevel++;
        ManageArrowButtons();
        ShowCurrentLevel();
    }

    public void OnClickBack()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void OnClickAchievements()
    {
        SceneManager.LoadScene("Achievements");
    }

    public void OnClickSettings()
    {
        PlayerPrefs.SetString("PreviousScene", "Level Selector");
        SceneManager.LoadScene("Settings Menu");
    }

    // Continues playing the game after the player has finished it.
    public void OnClickContinuePlaying()
    {
        FinishedGamePanel.SetActive(false);
        ManageArrowButtons();
        ShowCurrentLevel();
    }

    // Manages the visibility of arrow buttons based on the current level.
    private void ManageArrowButtons()
    {
        LeftButton.gameObject.SetActive(CurrentLevel == 0 ? false : true);
        RightButton.gameObject.SetActive(CurrentLevel == levels.Length - 1 ? false : true);
    }
}
