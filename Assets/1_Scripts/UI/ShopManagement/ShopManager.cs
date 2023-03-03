using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject[] tabs;
    [SerializeField] private RectTransform[] tabButtons;

    private int previousIndex = 10;

    private void Start()
    {
        _ShopPanelActiveness(false);
    }

    public void _ChangeTab(int index)
    {
        if(previousIndex == index)
        {
            _ShopPanelActiveness(false);
            previousIndex = 10;
            return;
        }

        _ShopPanelActiveness(true);
        previousIndex = index;

        ResetTabButtonsSize();
        foreach (var item in tabs)
            item.SetActive(false);

        tabs[index].SetActive(true);
        RectTransform rT = tabButtons[index];
        rT.sizeDelta = new Vector2(400, 125);
    }

    private void ResetTabButtonsSize()
    {
        foreach (var item in tabButtons)
            item.sizeDelta = new Vector2(400, 100);
    }

    public void _ShopPanelActiveness(bool x)
    {
        if (!x)
        {
            ResetTabButtonsSize();
            tabButtons[1].sizeDelta = new Vector2(400, 125);
        }
        shopPanel.SetActive(x);
    }
}
