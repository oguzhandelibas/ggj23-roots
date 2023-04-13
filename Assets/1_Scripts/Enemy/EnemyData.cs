using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public GameObject enemyObject;
    public Sprite enemySprite;

    public int Power;
    public float Speed;
    public int ScoreReward;
}
