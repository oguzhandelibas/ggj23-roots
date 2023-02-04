using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public int Power;
    public float Speed;
    public int ScoreReward;
}
