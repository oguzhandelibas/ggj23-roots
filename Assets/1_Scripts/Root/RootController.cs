using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootController : MonoBehaviour
{
    [SerializeField] private Color mainColor, targetColor;
    [SerializeField] private RootSpeedData rootSpeedData;
    [SerializeField] private Animator rootAnimatior;
    [SerializeField] private SpriteRenderer spriteRenderer;
    bool levelEnd;
    private void Start()
    {
        
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
    }
}
