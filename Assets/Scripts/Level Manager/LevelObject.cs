using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelObject : MonoBehaviour
{
    public Image[] Stars;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI Score;
    public Button StartLevel;
    public Image BlockedImage;

    /// Unlocks the level, updates the UI elements accordingly and sets the score and stars.
    public void Unlock(int levelNumber)
    {
        ActivateUIElements();
        SetStarts(levelNumber);
        SetScore(levelNumber);   
    }

    private void ActivateUIElements()
    {
        BlockedImage.gameObject.SetActive(false);
        ScoreText.gameObject.SetActive(true);
        Score.gameObject.SetActive(true);
        StartLevel.gameObject.SetActive(true);
        Stars[0].gameObject.SetActive(true);
    }

    private void SetStarts(int levelNumber)
    {
        int starsCount = PlayerPrefs.GetInt("Stars" + levelNumber, 0);
        Stars[starsCount].gameObject.SetActive(true);
    }

    private void SetScore(int levelNumber)
    {
        float score = PlayerPrefs.GetFloat("Score" + levelNumber, 0);
        Score.text = score.ToString("F2") + "%";
    }

}
