using System;
using UnityEngine;

public class RunningEnemyController : EnemyController
{
    [SerializeField] private GameObject impactEffect;
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
            col.gameObject.GetComponent<PlayerController>().TakeDamage(10);
            // TODO: Running Enemy hits the player
            var obj = Instantiate(impactEffect, transform.position, Quaternion.identity);
            
            Destroy(obj, 1);
            Destroy(gameObject);
        }
    }
}
