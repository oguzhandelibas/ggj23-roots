using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootController : MonoBehaviour
{
    [SerializeField] private RootSpeedData rootSpeedData;
    [SerializeField] private Animator rootAnimatior;
    
    private void Start()
    {
        rootAnimatior.speed = rootSpeedData.Speed;
    }
}
