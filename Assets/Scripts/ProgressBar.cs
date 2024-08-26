using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public TextMeshProUGUI progressPercentage;
    public Image sliderArea;

    // Start is called before the first frame update
    private void Start()
    {
        float progress = CalculateProgress();
        SetSliderValue(progress);
        SetSliderColor(progress);
    }

    private float CalculateProgress()
    {
        float maxScore = 500; // 5 levels * 100 points
        float totalScore = 0;

        for (int i = 0; i < 5; i++)
        {
            // Get the score of each level
            totalScore += PlayerPrefs.GetFloat("Score" + i, 0);
        }

        // Calculate the overall progress 
        return totalScore / maxScore * 100;
    }

    private void SetSliderValue(float progress)
    {
        progressPercentage.text = progress.ToString("F2") + "%";
        GetComponent<UnityEngine.UI.Slider>().value = progress / 100;
    }

    private void SetSliderColor(float progress)
    {
        Color32 red = new Color32(245, 62, 69, 255);
        Color32 yellow = new Color32(245, 200, 62, 255);
        Color32 green = new Color32(62, 245, 71, 255);

        sliderArea.color = progress < 50 ? red : progress < 70 ? yellow : green;
    }
}
