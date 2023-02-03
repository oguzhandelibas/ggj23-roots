using Rot.Stat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Health")]
public class Health : ScriptableObject, IDamageable
{
    public int CharacterHealth;
    public int InstanceId { get; private set; } = -1;

    public void Damage(int dmg)
    {
        CharacterHealth -= dmg;
    }
}
