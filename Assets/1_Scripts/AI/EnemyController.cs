using System;
using UnityEngine;
using Rot.Stat;
public class EnemyController : MonoBehaviour
{
    //[SerializeField] private Health enemyHealth;
    public int health = 10;
    [SerializeField] protected EnemyData EnemyData;

    protected Vector3 moveDirection;

    protected virtual void Start()
    {
        //enemyHealth.InitializeDamageble();
        moveDirection = transform.position.x > 0 ? Vector3.left : Vector3.right;
    }

    protected virtual void Update()
    {
        transform.Translate(Time.deltaTime * EnemyData.Speed * moveDirection);
        if (Vector3.Distance(Vector3.zero, transform.position) <= 0.5f)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) Destroy(gameObject);
        Debug.Log(health);
    }
}
