using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public enum EnemyTypes
    {
        Walking,
        Running,
        Flying
    }

    private const float X_RANGE_MAX = 21f;
    private const float X_RANGE_MIN = 15f;
    private const float Y_RANGE_MAX = 12f;
    private const float Y_RANGE_MIN = 2f;

    private const float STARTING_FLYING_SPAWN_RATE = 3f;
    private const float STARTING_WALKING_SPAWN_RATE = 3f;
    private const float STARTING_RUNNING_SPAWN_RATE = 3f;
    private const float STARTING_SPAWN_RATE_MULTIPLIER = 0.75f;

    [SerializeField] public EnemySpawnData enemySpawnData;
    [SerializeField] private GameObject walkingEnemyPrefab;
    [SerializeField] private GameObject runningEnemyPrefab;
    [SerializeField] private GameObject flyingEnemyPrefab;

    private void Start()
    {
        enemySpawnData.FlyingEnemySpawnRate = STARTING_FLYING_SPAWN_RATE;
        enemySpawnData.WalkingEnemySpawnRate = STARTING_WALKING_SPAWN_RATE;
        enemySpawnData.RunningEnemySpawnRate = STARTING_RUNNING_SPAWN_RATE;
        enemySpawnData.SpawnRateMultiplier = STARTING_SPAWN_RATE_MULTIPLIER;
        
        StartCoroutine(SpawnEnemy(EnemyTypes.Walking));
        StartCoroutine(SpawnEnemy(EnemyTypes.Running));
        StartCoroutine(SpawnEnemy(EnemyTypes.Flying));
        StartCoroutine(ChangeSpawnRate());
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
        int isOnRight = Random.Range(0, 2); // Generate 0 or 1 to determine left or right side
        if (isOnRight == 1)
        {
            return new Vector3(Random.Range(X_RANGE_MIN-1, X_RANGE_MAX), Random.Range(Y_RANGE_MIN, Y_RANGE_MAX), 0);
        }
        return new Vector3(Random.Range(-X_RANGE_MAX, -X_RANGE_MIN+1), Random.Range(Y_RANGE_MIN, Y_RANGE_MAX), 0);
    }

    // Enemy spawning does not stop
    private IEnumerator SpawnEnemy(EnemyTypes enemyType)
    {
        Vector3 spawnPosition;
        Collider enemyCollider = null;
        switch (enemyType)
        {
            case EnemyTypes.Walking:
                spawnPosition = GetGroundSpawnPosition();
                GameObject walkingEnemyGO = Instantiate(walkingEnemyPrefab, spawnPosition, walkingEnemyPrefab.transform.rotation);
                if (spawnPosition.x > 0)
                {
                    Vector3 transformLocalScale = walkingEnemyGO.transform.localScale;
                    transformLocalScale.x *= -1;
                    walkingEnemyGO.transform.localScale = transformLocalScale;
                }
                EnemyManager.Instance.AddEnemy(walkingEnemyGO.GetComponent<Enemy>());
                yield return new WaitForSeconds(enemySpawnData.WalkingEnemySpawnRate);
                break;
            case EnemyTypes.Running:
                spawnPosition = GetGroundSpawnPosition();
                GameObject runningEnemyGO = Instantiate(runningEnemyPrefab, spawnPosition, walkingEnemyPrefab.transform.rotation);
                if (spawnPosition.x > 0)
                {
                    Vector3 transformLocalScale = runningEnemyGO.transform.localScale;
                    transformLocalScale.x *= -1;
                    runningEnemyGO.transform.localScale = transformLocalScale;
                }
                EnemyManager.Instance.AddEnemy(runningEnemyGO.GetComponent<Enemy>());
                yield return new WaitForSeconds(enemySpawnData.RunningEnemySpawnRate);
                break;
            case EnemyTypes.Flying:
                spawnPosition = GetAirSpawnPosition();
                GameObject flyingEnemyGO = Instantiate(flyingEnemyPrefab, spawnPosition, walkingEnemyPrefab.transform.rotation);
                if (spawnPosition.x < 0)
                {
                    Vector3 transformLocalScale = flyingEnemyGO.transform.localScale;
                    transformLocalScale.x *= -1;
                    flyingEnemyGO.transform.localScale = transformLocalScale;
                }
                EnemyManager.Instance.AddEnemy(flyingEnemyGO.GetComponent<Enemy>());
                yield return new WaitForSeconds(enemySpawnData.FlyingEnemySpawnRate);
                break;
            default:    // Spawn walking enemy in case of an error
                Instantiate(walkingEnemyPrefab, GetGroundSpawnPosition(), walkingEnemyPrefab.transform.rotation);
                yield return new WaitForSeconds(enemySpawnData.WalkingEnemySpawnRate);
                break;
        }
        
        StartCoroutine(SpawnEnemy(enemyType));
    }

    private IEnumerator ChangeSpawnRate()
    {
        yield return new WaitForSeconds(enemySpawnData.WaitToSpawn);
        enemySpawnData.FlyingEnemySpawnRate *= enemySpawnData.SpawnRateMultiplier;
        enemySpawnData.WalkingEnemySpawnRate *= enemySpawnData.SpawnRateMultiplier;
        enemySpawnData.RunningEnemySpawnRate *= enemySpawnData.SpawnRateMultiplier;

        StartCoroutine(ChangeSpawnRate());
    }
}
