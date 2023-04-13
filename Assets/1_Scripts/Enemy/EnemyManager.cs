using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    public List<Enemy> enemyColliderList;

    public void AddEnemy(Enemy enemy)
    {
        if (enemy == null) return;
        enemyColliderList.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemyColliderList.Remove(enemy);
    }
}
