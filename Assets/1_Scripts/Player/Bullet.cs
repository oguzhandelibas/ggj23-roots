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
            collision.GetComponent<EnemyController>().TakeDamage(bulletData.Damage);
            Destroy(gameObject);

            /*
            Debug.Log("1");
            int colliderInstanceId = collision.GetInstanceID();
            if (DamageableHelper.DamagebleList.ContainsKey(colliderInstanceId))
            {
                Debug.Log("2");
                DamageableHelper.DamagebleList[colliderInstanceId].Damage(bulletData.Damage);
            }*/
        }
    }
}
