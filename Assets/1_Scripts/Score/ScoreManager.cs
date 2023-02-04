using Rot.Control;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private const int SCORE_NEEDED_FOR_UPGRADE = 10;
    
    [SerializeField] private GameObject player;
    private BulletData playerBulletData;
    private RootSpeedData playerRootSpeedData;
    private int score;
    private int availableUpgradeCount;
    
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
}
