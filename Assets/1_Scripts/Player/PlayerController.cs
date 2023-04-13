using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private const int STARTING_HEALTH = 100;
    private const int STARTING_BULLET_DAMAGE = 10;
    private const float STARTING_ROOT_SPEED = 0.3f;

    private List<Color> colorList = new List<Color>()
    {
        Color.white,
        new Color(0.474f, 0.078f, 0.988f, 1f),  // purple
        new Color(0.988f, 0.078f, 0.823f, 1f),  // pink
        new Color(0.85f, 0.078f, 0.078f, 1f),  // red
        new Color(0.784f, 0.325f, 0f, 1f),  // orange
        Color.yellow,
        new Color(0.388f, 1f, 0.211f, 1f)   // green
    };

    [SerializeField] private DamageArea damageArea;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private Health playerHealth;
    public BulletData bulletData;

    [SerializeField] private RootController rootController;
    [SerializeField] private RootSpeedData rootSpeedData;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform aimTransform;
    [SerializeField] private GameObject lightningPrefab;
    [SerializeField] private LayerMask layerMask;

    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private GameObject losePanel;

    [SerializeField] private Image healthBar;

    internal BulletData BulletPowerData
    {
        get => bulletData;
        set => bulletData = value;
    }

    internal RootSpeedData RootSpeedData
    {
        get => rootSpeedData;
        set => rootSpeedData = value;
    }
    
    public bool isDead;

    private void Start()
    {
        playerHealth.CharacterHealth = STARTING_HEALTH;
        bulletData.Damage = STARTING_BULLET_DAMAGE;
        rootSpeedData.Speed = STARTING_ROOT_SPEED;
    }
    
    private void Update()
    {
        /*
            Vector3 aimDirection = (mousePos - aimTransform.position).normalized;
            float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
            aimTransform.eulerAngles = new Vector3(0, 0, angle);*/

        if (Input.GetMouseButtonDown(0))
        {
            CheckEnemy();
        }

        if (Input.GetMouseButtonUp(0))
        {
            damageArea.SetArea(false, Vector3.zero);
        }
    }

    private void CheckEnemy()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        damageArea.SetArea(true, Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (hit.collider != null && hit.collider.tag == "Enemy")
        {
            
        }
        CreateLightning(mousePos);

        
    }

    

    public void TakeDamage(int damage)
    {
        if (isDead) return;
        isDead = playerHealth.TakeDamage(damage);
        healthBar.fillAmount = (float)playerHealth.CharacterHealth / 100;
        if (isDead)
        {
            losePanel.transform.parent = null;
            losePanel.SetActive(true);
            CameraShake.Instance.ShakeActive = true;
            CameraShake.Instance.shakeDuration = 0.35f;
            enemySpawner.gameObject.SetActive(false);
            rootController.gameObject.SetActive(false);
            var obj = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(obj, 1);
            Destroy(gameObject);
            
        }
        CameraShake.Instance.ShakeActive = true;
        CameraShake.Instance.shakeDuration = 0.1f;
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

    public void ChangeLightningColor(int bulletLevel)
    {
        LineRenderer lineRenderer = lightningPrefab.GetComponent<LineRenderer>();
        if (bulletLevel <= 7)
        {
            lineRenderer.startColor = colorList[bulletLevel - 1];
            lineRenderer.endColor = colorList[bulletLevel - 1];
        }
    }
}


