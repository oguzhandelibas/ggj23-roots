using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootGenerator : MonoBehaviour
{
    [SerializeField] private RootSpeedData rootSpeedData;
    [SerializeField] private Transform[] trailRenderers;
    private bool down, done;

    private void Start()
    {
        CalculatePath();
    }

    IEnumerator GenerateRoot()
    {
        yield return new WaitForSeconds(rootSpeedData.Speed);
        CalculatePath();
    }

    private void CalculatePath()
    {
        Vector3 targetPos;
        int a = 1;
        for (int i = 0; i < trailRenderers.Length; i++)
        {
            if (down)
                targetPos = new Vector3(0, -Random.Range(0.25f, 2.75f), 0);
            else
                targetPos = new Vector3(Random.Range(-3, 4f), 0, 0);

            print(targetPos);
            trailRenderers[i].transform.position += targetPos;
        }
        down = !down;
        if (!done) StartCoroutine(GenerateRoot());

    } 
}
