using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] protected EnemyData EnemyData;

    protected Vector3 moveDirection;

    protected virtual void Start()
    {
        moveDirection = transform.position.x > 0 ? Vector3.left : Vector3.right;
    }

    protected virtual void Update()
    {
        transform.Translate(Time.deltaTime * EnemyData.Speed * moveDirection);
    }
}
