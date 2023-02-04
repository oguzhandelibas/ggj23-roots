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

    public void DowngradeRoot()
    {
        StartCoroutine(DowngradeRootRoutine());
    }

    IEnumerator DowngradeRootRoutine()
    {
        rootAnimatior.speed = -rootSpeedData.Speed*2;
        yield return new WaitForSeconds(0.75f);
        rootAnimatior.speed = rootSpeedData.Speed;
    }
}
