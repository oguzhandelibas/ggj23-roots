using System;
using System.Collections;
using _1_Scripts.Enums;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    private const float X_RANGE_MAX = 14f;
    private const float X_RANGE_MIN = 10f;
    private const float Y_RANGE_MAX = 8f;
    private const float Y_RANGE_MIN = 6f;
    
    [SerializeField] private EnemySpawnData enemySpawnData;
    [SerializeField] private GameObject walkingEnemyPrefab;
    [SerializeField] private GameObject runningEnemyPrefab;
    [SerializeField] private GameObject flyingEnemyPrefab;

    private void Start()
    {
        StartCoroutine(SpawnEnemy(EnemyType.Walking));
        StartCoroutine(SpawnEnemy(EnemyType.Running));
        StartCoroutine(SpawnEnemy(EnemyType.Flying));
    }

    private Vector3 GetGroundSpawnPosition()
    {
        int isOnRight = Random.Range(0, 2); // Generate 0 or 1 to determine left or right side
        if (isOnRight == 1)
        {
            return new Vector3(Random.Range(X_RANGE_MIN, X_RANGE_MAX), 0, 0);
        }
        return new Vector3(Random.Range(-X_RANGE_MAX, -X_RANGE_MIN), 0, 0);
    }

    private Vector3 GetAirSpawnPosition()
    {
        return new Vector3(Random.Range(-X_RANGE_MAX, X_RANGE_MAX), Random.Range(Y_RANGE_MIN, Y_RANGE_MAX), 0);
    }

    // Enemy spawning does not stop
    private IEnumerator SpawnEnemy(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.Walking:
                Instantiate(walkingEnemyPrefab, GetGroundSpawnPosition(), walkingEnemyPrefab.transform.rotation);
                yield return new WaitForSeconds(enemySpawnData.WalkingEnemySpawnRate);
                break;
            case EnemyType.Running:
                Instantiate(runningEnemyPrefab, GetGroundSpawnPosition(), walkingEnemyPrefab.transform.rotation);
                yield return new WaitForSeconds(enemySpawnData.RunningEnemySpawnRate);
                break;
            case EnemyType.Flying:
                Instantiate(flyingEnemyPrefab, GetAirSpawnPosition(), walkingEnemyPrefab.transform.rotation);
                yield return new WaitForSeconds(enemySpawnData.FlyingEnemySpawnRate);
                break;
            default:    // Spawn walking enemy in case of an error
                Instantiate(walkingEnemyPrefab, GetGroundSpawnPosition(), walkingEnemyPrefab.transform.rotation);
                yield return new WaitForSeconds(enemySpawnData.WalkingEnemySpawnRate);
                break;
        }

        StartCoroutine(SpawnEnemy(enemyType));
    }
}
