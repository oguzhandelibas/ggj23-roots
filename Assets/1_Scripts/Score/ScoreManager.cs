using Rot.Control;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    
    [SerializeField] private GameObject player;
    private BulletData playerBulletData;
    private RootSpeedData playerRootSpeedData;
    private int score;
    
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
    }
}
