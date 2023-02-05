using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RootController : MonoBehaviour
{
    [SerializeField] private Color mainColor, targetColor;
    [SerializeField] private RootSpeedData rootSpeedData;
    [SerializeField] private Animator rootAnimatior;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private TextMeshProUGUI levelEndTimer;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private CapsuleCollider2D playerCollider;
    bool levelEnd;
    private void Start()
    {
        levelEndTimer.gameObject.SetActive(false);
        rootAnimatior.speed = rootSpeedData.Speed;
        levelEnd = false;
        spriteRenderer.color = mainColor;
    }

    private void Update()
    {
        if(levelEnd) spriteRenderer.color = Color.Lerp(mainColor, targetColor, Mathf.PingPong(Time.time, 1));
    }

    public void RootColorChange()
    {
        levelEnd = true;
        levelEndTimer.gameObject.SetActive(true);
        StartCoroutine(LevelEndTimeRoutine());
    }

    IEnumerator LevelEndTimeRoutine()
    {
        for (int time = 10; time > 0; time--)
        {
            levelEndTimer.text = "TIME TO COMPLETE EXPLOITATON: " + time.ToString() + "s";
            yield return new WaitForSeconds(1);
        }
        playerCollider.enabled = false;
        winPanel.SetActive(true);
    }
}
