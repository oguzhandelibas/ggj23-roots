using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    //[SerializeField] private Health enemyHealth;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private int Health = 10;
    [SerializeField] protected EnemyData EnemyData;
    public GameObject deadEffect;

    protected Vector3 moveDirection;

    protected virtual void Start()
    {
        //enemyHealth.InitializeDamageble();
        moveDirection = transform.position.x > 0 ? Vector3.left : Vector3.right;
    }

    protected virtual void Update()
    {
        transform.Translate(Time.deltaTime * EnemyData.Speed * moveDirection);
    }

    public bool TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Dead();
            return true;
        }

        return false;
    }

    public void Dead()
    {
        var obj = Instantiate(deadEffect, gameObject.transform.GetChild(0).position, Quaternion.identity);
        EnemyManager.Instance.RemoveEnemy(this);
        ScoreManager.Instance.IncreaseScore(EnemyData.ScoreReward);
        Destroy(obj, 1);
        Destroy(gameObject);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DamageArea")
        {
            CameraShake.Instance.ShakeActive = true;
            CameraShake.Instance.shakeDuration = 0.02f;

            bool isDead = TakeDamage(collision.GetComponentInParent<PlayerController>().bulletData.Damage);
            if (!isDead) Instantiate(hitEffect, transform.position, Quaternion.identity);

            StartCoroutine(ColorRoutine(GetComponent<SpriteRenderer>()));
        }
    }

    IEnumerator ColorRoutine(SpriteRenderer spriteRenderer)
    {
        if (spriteRenderer != null) spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.15f);
        if (spriteRenderer != null) spriteRenderer.color = Color.white;
    }
}
