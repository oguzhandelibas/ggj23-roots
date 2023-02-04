using System;
using System.Collections;
using UnityEngine;

public class WalkingEnemyController : EnemyController
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            StartCoroutine(GiveDamage(col.gameObject.GetComponent<PlayerController>()));
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    IEnumerator GiveDamage(PlayerController playerController)
    {
        while (!playerController.isDead)
        {
            playerController.TakeDamage(5);
            yield return new WaitForSeconds(1);
        }
    }
}