using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private const int SCORE_NEEDED_FOR_UPGRADE = 10;
    private const int BULLET_POWER_INCREASE_AMOUNT = 5;
    private const float ROOT_SPEED_INCREASE_AMOUNT = 0.05f;
    
    [SerializeField] private GameObject player;
    private Animator rootAnimator;
    private BulletData playerBulletData;
    private RootSpeedData playerRootSpeedData;
    
    private int score;
    private int availableUpgradeCount;
    private int bulletLevel = 1;
    private int rootSpeedLevel = 1;

    public int AvailableUpgradeCount => availableUpgradeCount;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
    }

    private void Start()
    {
        PlayerController playerControllerScript = player.GetComponent<PlayerController>();
        playerBulletData = playerControllerScript.BulletPowerData;
        playerRootSpeedData = playerControllerScript.RootSpeedData;
        rootAnimator = GameObject.Find("RootController").GetComponent<Animator>();
        score = 0;
    }

    public void IncreaseScore(int increaseAmount)
    {
        score += increaseAmount;
        if (score >= SCORE_NEEDED_FOR_UPGRADE)
        {
            availableUpgradeCount += score / SCORE_NEEDED_FOR_UPGRADE;
            score %= SCORE_NEEDED_FOR_UPGRADE;
        }
    }

    public void UpgradeBulletPower()
    {
        playerBulletData.Damage += BULLET_POWER_INCREASE_AMOUNT;
        bulletLevel++;
        availableUpgradeCount--;
        Debug.Log("bullet power: " + playerBulletData.Damage);
    }

    public void UpgradeRootSpeed()
    {
        playerRootSpeedData.Speed += ROOT_SPEED_INCREASE_AMOUNT;
        rootAnimator.speed = playerRootSpeedData.Speed;
        rootSpeedLevel++;
        availableUpgradeCount--;
        Debug.Log("root speed: " + playerRootSpeedData.Speed);
    }
}
