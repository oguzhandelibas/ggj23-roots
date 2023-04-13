using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlanetInformationManager : MonoBehaviour
{
    [SerializeField] private GameObject informationPanel;
    [SerializeField] private PlanetManager planetManager;

    [Header("PlanetInfo Panel UI's")]
    #region UI
    [SerializeField] private Image planetImage;
    [SerializeField] private TextMeshProUGUI planetName;
    [SerializeField] private TextMeshProUGUI planetExplanation;

    [SerializeField] private Image[] enemyTypes;

    [Header("Difficulty Indicator")]
    [SerializeField] private Image[] difficultyIndicators;
    private void SetDifficultyIndicatorVisibility(int count)
    {
        for (int i = 0; i < count; i++)
        {
            difficultyIndicators[i].color = Color.red;
        }
        for (int i = count; i < difficultyIndicators.Length; i++)
        {
            difficultyIndicators[i].color = Color.white;
        }
    }
    #endregion

    public void _ActivateInformationPanel()
    {
        foreach (var item in enemyTypes)
        {
            item.gameObject.SetActive(false);
        }

        PlanetData planetData = planetManager.CurrentPlanetData();

        SetDifficultyIndicatorVisibility((int)planetData.difficultyType+1);

        planetImage.sprite = planetData.planetEarth;
        planetName.text = planetData.planetName;
        planetExplanation.text = planetData.planetExplanation;

        for (int i = 0; i < planetData.enemyData.Length; i++)
        {
            enemyTypes[i].sprite = planetData.enemyData[i].enemySprite;
            enemyTypes[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Speed: " + planetData.enemyData[i].Speed.ToString();
            enemyTypes[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Attack: " + planetData.enemyData[i].Power.ToString();
            enemyTypes[i].gameObject.SetActive(true);
        }

        informationPanel.SetActive(true);
    }

    public void _ChangeInformationPanel(int value)
    {
        planetManager._NextPlanet(value);
        _ActivateInformationPanel();
    }
}
