using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Health")]
public class Health : ScriptableObject, IDamageable
{
    public int CharacterHealth;

    public void TakeDamage(int damage)
    {
        CharacterHealth -= damage;
    }
}
