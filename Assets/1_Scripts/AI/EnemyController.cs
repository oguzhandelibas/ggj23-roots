using System;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{
    //[SerializeField] private Health enemyHealth;
    private int Health = 10;
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
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0) Destroy(gameObject);
        Debug.Log(Health);
    }
}
