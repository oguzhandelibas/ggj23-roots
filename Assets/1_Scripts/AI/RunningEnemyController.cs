using System;
using UnityEngine;

public class RunningEnemyController : EnemyController
{
    private Animator runningEnemyAnimator;

    protected override void Start()
    {
        base.Start();
        runningEnemyAnimator = GetComponent<Animator>();
        runningEnemyAnimator.speed = 2f;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            // TODO: Running Enemy hits the player
        }
    }
}
