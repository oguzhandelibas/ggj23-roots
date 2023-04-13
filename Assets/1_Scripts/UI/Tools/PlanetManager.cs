using System.Transactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetManager : MonoBehaviour
{
    [SerializeField] private Planet[] planetList;
    [SerializeField] private Vector2 normalScale, wantedScale;

    private int currentIndex = 0;

    private void Start()
    {
        currentIndex = 0;
        SetScale(currentIndex);
    }

    public void _NextPlanet(int value)
    {
        if (currentIndex + value > planetList.Length - 1)
            currentIndex = 0;
        else if (currentIndex + value < 0)
            currentIndex = planetList.Length - 1;
        else
            currentIndex += value;
        SetScale(currentIndex);
    }

    private void SetScale(int index)
    {
        foreach (var item in planetList)
        {
            item.transform.localScale = normalScale;
            SetColor(item.transform, 0.2f);
        }
        transform.localPosition = -new Vector2(696 * currentIndex, 0);
        planetList[index].transform.localScale = wantedScale;
        SetColor(planetList[index].transform, 1.0f);
    }

    private void SetColor(Transform planetTransform, float alfa)
    {
        Image planetImage = planetTransform.GetComponent<Image>();
        planetImage.color = new Color(planetImage.color.r, planetImage.color.g, planetImage.color.b, alfa);
    }

    public PlanetData CurrentPlanetData()
    {
        return planetList[currentIndex].CurrentPlanetData();
    }

}
