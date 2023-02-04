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
    [SerializeField] private CameraShake cameraShake;
    [SerializeField] private GameObject losePanel;

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
                cameraShake.ShakeActive = true;
                cameraShake.shakeDuration = 0.1f;
                hit.collider.GetComponent<EnemyController>().TakeDamage(bulletData.Damage);
               
                StartCoroutine(ColorRoutine(hit.collider.GetComponent<SpriteRenderer>()));
            }
            CreateLightning(mousePos);
        }
    }

    IEnumerator ColorRoutine(SpriteRenderer spriteRenderer)
    {
        if(spriteRenderer!=null)spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.15f);
        if(spriteRenderer!=null)spriteRenderer.color = Color.white;
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;
        isDead = playerHealth.TakeDamage(damage);
        if (isDead)
        {
            losePanel.transform.parent = null;
            losePanel.SetActive(true);
            cameraShake.ShakeActive = true;
            cameraShake.shakeDuration = 0.35f;
            enemySpawner.gameObject.SetActive(false);
            rootController.gameObject.SetActive(false);
            var obj = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(obj, 1);
            Destroy(gameObject);
            
        }
        cameraShake.ShakeActive = true;
        cameraShake.shakeDuration = 0.1f;
        //rootController.DowngradeRoot();
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


