using System;
using UnityEngine;

public class WalkingEnemyController : EnemyController
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit");
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}