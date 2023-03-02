using System.Transactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeMenu : MonoBehaviour
{
    [SerializeField] private Transform[] planetList;
    [SerializeField] private Vector2 normalScale, wantedScale;

    private int currentIndex = 0;

    private void Awake()
    {
    }

    private void Start()
    {
        currentIndex = 0;
        SetScale(currentIndex);
    }

    public void NextPlanet(int value)
    {
        if (currentIndex + value > planetList.Length-1)
            currentIndex = 0;
        else if (currentIndex + value < 0)
            currentIndex = planetList.Length-1;
        else
            currentIndex += value;
        SetScale(currentIndex);
    }

    private void SetScale(int index)
    {
        print(index);
        foreach (var item in planetList)
        {
            item.localScale = normalScale;
            SetColor(item, 0.2f);
        }
        transform.localPosition = -new Vector2(696 * currentIndex, 0);
        planetList[index].localScale = wantedScale;
        SetColor(planetList[index], 1.0f);
    }

    private void SetColor(Transform planetTransform, float alfa)
    {
        Image planetImage = planetTransform.GetComponent<Image>();
        planetImage.color = new Color(planetImage.color.r, planetImage.color.g, planetImage.color.b, alfa);
    }
}
