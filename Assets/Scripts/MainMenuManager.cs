using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject ChooseCharacterPanel;
    public GameObject MainMenuPanel;
    public GameObject IntroPanel;
    public GameObject MainCharacter;

    public void OnClickStartGame()
    {
        // If the player is in the Main Menu, check if the player has chosen a character.
        if (MainMenuPanel.activeInHierarchy)
        {
            // If the player has just started the game, show the intro panel.
            if (PlayerPrefs.GetString("Character") == "")
            {
                ShowIntro();
            }
            
            // If the player has chosen a character, load the Level Selector scene.
            else
            {
                SceneManager.LoadScene("Level Selector");
            }
        }
        // If the player is in the Choose Character panel, save the character choice and load the Level Selector scene.
        else
        {
            ChooseCharacter();
            SceneManager.LoadScene("Level Selector");
        }
    }

    public void ShowIntro() {
        MainMenuPanel.SetActive(false);
        IntroPanel.SetActive(true);
        IntroPanel.transform.GetChild(2).gameObject.SetActive(true); // Activate play button
    }

    public void ActivateChooseCharacterPanel()
    {
        MainMenuPanel.SetActive(false);
        ChooseCharacterPanel.SetActive(true);
        MainCharacter.SetActive(true);
    }

    /// Chooses the character the player will play as based on the character selected.
    private void ChooseCharacter()
    {
        if (MainCharacter.activeInHierarchy)
        {
            PlayerPrefs.SetString("Character", "Mother");
        }
        else
        {
            PlayerPrefs.SetString("Character", "Father");
        }
    }

    public void OnClickSettings()
    {
        PlayerPrefs.SetString("PreviousScene", "Main Menu");
        SceneManager.LoadScene("Settings Menu");
    }

    public void OnClickQuitGame()
    {
        Application.Quit();
    }
}
