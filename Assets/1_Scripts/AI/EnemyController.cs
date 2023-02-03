using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] protected Health enemyHealth;
    [SerializeField] protected int enemyPower;
    [SerializeField] protected float speed;

    protected Vector3 moveDirection;

    private void Start()
    {
        moveDirection = transform.position.x > 0 ? Vector3.left : Vector3.right;
    }

    private void Update()
    {
        transform.Translate(Time.deltaTime * speed * moveDirection);
    }
}
