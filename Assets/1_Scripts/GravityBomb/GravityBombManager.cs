using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBombManager : MonoBehaviour
{
    public float fieldofImpact;
    public float force;
    public LayerMask LayerToHit;
    public GameObject ExplosionEffect;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Explode();
    }

    public void Explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldofImpact, LayerToHit);

        foreach (Collider2D item in objects)
        {
            Vector2 direction = item.transform.position - transform.position;
            item.GetComponent<Rigidbody2D>().AddForce(direction * force);
            print(item.GetComponent<EnemyController>());
        }

        //GameObject ExplosionEffectIns = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldofImpact);
    }
}
