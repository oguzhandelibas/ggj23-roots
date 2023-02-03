using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rot.Stat;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletData bulletData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            int colliderInstanceId = collision.GetInstanceID();
            if (DamageableHelper.DamagebleList.ContainsKey(colliderInstanceId))
            {
                DamageableHelper.DamagebleList[colliderInstanceId].Damage(bulletData.Damage);
            }
        }
    }
}
