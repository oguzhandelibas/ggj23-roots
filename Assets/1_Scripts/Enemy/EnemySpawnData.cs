using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EnemySpawnData")]
public class EnemySpawnData : ScriptableObject
{
    [Header("Spawn Rate")]
    public float WalkingEnemySpawnRate;
    public float RunningEnemySpawnRate;
    public float FlyingEnemySpawnRate;

    [Header("Spawn Rate Multiplier")]
    public float SpawnRateMultiplier;
    public float WaitToSpawn;
}
