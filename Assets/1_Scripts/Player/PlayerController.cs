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
        [SerializeField] private Transform aimTransform;

        public void Shoot(Vector3 origin, Vector3 target)
        {
            GameObject obj = Instantiate(bullet, origin, Quaternion.Euler(aimTransform.localEulerAngles));
            obj.GetComponent<Rigidbody2D>().AddForce(target * 5, ForceMode2D.Impulse);
            Destroy(obj, 3);
        }

        private void Update()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 aimDirection = (mousePos - aimTransform.position).normalized;
            float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
            aimTransform.eulerAngles = new Vector3(0, 0, angle);
            
            if (Input.GetMouseButtonDown(0))
            {
                Shoot(aimTransform.position, mousePos);
            }
        }
    }
}

