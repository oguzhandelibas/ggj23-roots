using UnityEngine;

public class FlyingEnemyController : EnemyController
{
    protected override void Start()
    {
        moveDirection = Vector3.zero - transform.position;
        moveDirection.Normalize();
    }
}