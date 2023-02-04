using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EnemySpawnData")]
public class EnemySpawnData : ScriptableObject
{
    public float WalkingEnemySpawnRate;
    public float RunningEnemySpawnRate;
    public float FlyingEnemySpawnRate;
    public float SpawnRateMultiplier;
    public float SpawnRateMultiplyRate;
}
