using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private Health playerHealth;
    [SerializeField] private BulletData bulletData;

    [SerializeField] private RootController rootController;
    [SerializeField] private RootSpeedData rootSpeedData;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform aimTransform;
    [SerializeField] private GameObject lightningPrefab;
    [SerializeField] private LayerMask layerMask;

    [SerializeField] private GameObject explosionEffect;

    public bool isDead;

    private void Start()
    {
        playerHealth.CharacterHealth = 100;
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

    public void TakeDamage(int damage)
    {
        if (isDead) return;
        isDead = playerHealth.TakeDamage(damage);
        if (isDead)
        {
            enemySpawner.gameObject.SetActive(false);
            rootController.gameObject.SetActive(false);
            Destroy(gameObject, 1);
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }
        rootController.DowngradeRoot();
    }


    public void CreateLightning(Vector3 targetPos)
    {
        var obj = Instantiate(lightningPrefab, transform.position, Quaternion.identity);

        obj.transform.GetChild(0).position = new Vector3(0f, 2.25f, 0f);
        obj.transform.GetChild(1).position = targetPos;
        obj.transform.position = new Vector3(0, 0, 1);
        Destroy(obj, 0.25f);
    }
}


