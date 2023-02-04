using System;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{
    //[SerializeField] private Health enemyHealth;
    [SerializeField] private int Health = 10;
    [SerializeField] protected EnemyData EnemyData;
    public GameObject deadEffect;

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

    public bool TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Dead();
            return true;
        }

        return false;
    }

    public void Dead()
    {
        var obj = Instantiate(deadEffect, transform.position, Quaternion.identity);
        Destroy(obj, 1);
        Destroy(gameObject);
        ScoreManager.Instance.IncreaseScore(EnemyData.ScoreReward);
    }
}
