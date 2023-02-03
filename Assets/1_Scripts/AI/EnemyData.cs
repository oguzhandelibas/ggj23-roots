using Rot.Stat;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EnemyData")]
public class EnemyData : ScriptableObject, IDamageable
{
    public int Health;
    public int Power;
    public float Speed;

    public int InstanceId { get; }

    public void Damage(int dmg)
    {
        Health -= dmg;
    }
}
