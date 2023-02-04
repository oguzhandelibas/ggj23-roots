using System;
using UnityEngine;

public class WalkingEnemyController : EnemyController
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}