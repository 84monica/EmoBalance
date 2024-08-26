using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class AchievementsMenuManager : MonoBehaviour
{
    public GameObject DetailsPanel;
    public GameObject StrategiesPanel;
    public Sprite[] StrategySprites;
    public TextAsset JsonFile;
    private Strategies strategiesJsonData;
    public bool isAchievementsMenu = true;

    private void Start()
    {
        strategiesJsonData = JsonUtility.FromJson<Strategies>(JsonFile.text);
        if (isAchievementsMenu) UnlockAchievements();
    }

    private void UnlockAchievements() {
        Transform buttons = StrategiesPanel.transform.GetChild(0).GetChild(0);

        for (int i = 0; i < strategiesJsonData.strategies.Length; i++)
        {
            if (PlayerPrefs.GetString("Trophie" + i.ToString(), "Locked") == "Unlocked")
            {
                Transform strategy = buttons.transform.GetChild(i);
                strategy.GetChild(0).gameObject.SetActive(true);
                strategy.GetChild(1).gameObject.SetActive(true);
                strategy.GetChild(2).gameObject.SetActive(false);
                strategy.GetComponent<Button>().interactable = true;
            }
        }
    }

    public void OnClickBack()
    {
        SceneManager.LoadScene("Level Selector");
    }

    public void OnClickSettings()
    {
        PlayerPrefs.SetString("PreviousScene", "Achievements");
        SceneManager.LoadScene("Settings Menu");
    }

    /// This method is called when a strategy button is clicked. It displays the details of the strategy.
    public void OnClickStrategyButton(int strategyId)
    {
        ShowStrategyPanel(strategyId);
        DetailsPanel.SetActive(true);
        StrategiesPanel.SetActive(false);
    }

    public void ShowStrategyPanel(int strategyId)
    {
        Transform panel = DetailsPanel.transform.GetChild(0);

        panel.GetChild(1).GetComponent<TextMeshProUGUI>().text = strategiesJsonData.strategies[strategyId].name;
        panel.GetChild(2).GetComponent<TextMeshProUGUI>().text = strategiesJsonData.strategies[strategyId].description;
        panel.GetChild(3).GetComponent<Image>().sprite = StrategySprites[strategyId];
    }
}
