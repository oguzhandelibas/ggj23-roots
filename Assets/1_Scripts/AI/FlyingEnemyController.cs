using System;
using UnityEngine;

public class FlyingEnemyController : EnemyController
{
    protected override void Start()
    {
        moveDirection = Vector3.zero - transform.position;
        moveDirection.Normalize();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            // TODO: Flying Enemy hits the player
        }
    }
}