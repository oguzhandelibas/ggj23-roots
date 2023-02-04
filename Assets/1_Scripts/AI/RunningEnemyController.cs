using UnityEngine;

public class RunningEnemyController : EnemyController
{
    private Animator runningEnemyAnimator;

    protected override void Start()
    {
        base.Start();
        runningEnemyAnimator = GetComponent<Animator>();
        runningEnemyAnimator.speed = 2f;
    }
}
