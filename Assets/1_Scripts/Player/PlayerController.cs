using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rot.Control
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Health playerHealth;
        [SerializeField] private BulletData bulletData;
        [SerializeField] private RootSpeedData rootSpeedData;

        [SerializeField] private GameObject bullet;
        [SerializeField] private Transform aimTransform;
        [SerializeField] private GameObject lightningPrefab;
        [SerializeField] private LayerMask layerMask;

        private void Awake()
        {
            
        }

        private void Update()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);/*
            Vector3 aimDirection = (mousePos - aimTransform.position).normalized;
            float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
            aimTransform.eulerAngles = new Vector3(0, 0, angle);*/
            
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit.collider != null && hit.collider.tag == "Enemy")
                {
                    hit.collider.GetComponent<EnemyController>().TakeDamage(bulletData.Damage);
                }
                CreateLightning(mousePos);
            }
        }

        public void Shoot(Vector3 origin, Vector3 target)
        {
            GameObject obj = Instantiate(bullet, origin, Quaternion.Euler(aimTransform.localEulerAngles));
            obj.GetComponent<Rigidbody2D>().AddForce(target * 5, ForceMode2D.Impulse);
            Destroy(obj, 3);
        }
        public void CreateLightning(Vector3 targetPos)
        {
            var obj = Instantiate(lightningPrefab, transform.position, Quaternion.identity);
            
            obj.transform.GetChild(0).position = new Vector3(0f, 1f, 0f);
            obj.transform.GetChild(1).position = targetPos;
            obj.transform.position = new Vector3(0, 0, 1);
            Destroy(obj, 0.25f);
        }
    }
}

