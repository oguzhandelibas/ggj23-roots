using System;
using UnityEngine;

public class FlyingEnemyController : Enemy
{
    [SerializeField] private GameObject impactEffect;

    protected override void Start()
    {
        moveDirection = Vector3.zero - transform.position;
        moveDirection.Normalize();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerController>().TakeDamage(10);
            // TODO: Flying Enemy hits the player
            var obj = Instantiate(impactEffect, gameObject.transform.GetChild(0).position, Quaternion.identity);
            Destroy(obj, 1);
            Destroy(gameObject);
        }
    }
}