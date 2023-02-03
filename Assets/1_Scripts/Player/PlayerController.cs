using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rot.Stat;

namespace Rot.Control
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Health playerHealth;

        [SerializeField] private GameObject bullet;
        [SerializeField] private Transform firePoint;

        public void Shoot(Vector2 origin, Vector2 direction)
        {
            GameObject obj = Instantiate(bullet, firePoint.position, Quaternion.Euler(0,0,90));
            obj.GetComponent<Rigidbody2D>().AddForce(direction * 10, ForceMode2D.Impulse);
            Destroy(obj, 3);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Debug.Log(pos);
                Shoot(firePoint.position, pos); //mouse positiyon ile güncelle
            }
        }
    }
}

