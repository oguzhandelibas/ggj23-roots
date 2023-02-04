using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Health")]
public class Health : ScriptableObject, IDamageable
{
    public int CharacterHealth;

    public bool TakeDamage(int damage)
    {
        CharacterHealth -= damage;
        Debug.Log(CharacterHealth);
        if (CharacterHealth <= 0) return true;

        return false;
    }
}
