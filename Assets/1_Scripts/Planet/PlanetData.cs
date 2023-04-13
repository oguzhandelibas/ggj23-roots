using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ScriptableObjects/Planet/PlanetData")]
public class PlanetData : ScriptableObject
{
    public enum DifficultType { Easy, Medium, Hard, Expert, Veteran, Turkey }
    public DifficultType difficultyType;
    [HideInInspector] public int DifficultyLevel;

    [Header("-----Scriptable-----")]
    [SerializeField] private EnemySpawnData enemySpawnData;
    public EnemyData[] enemyData;


    [Header("-----Planet Info-----")]
    public string planetName;
    public string planetExplanation;
    public Sprite planetEarth;
    [SerializeField] private Sprite planetSky;


    public void SetDiffiulty()
    {
        int count = 0;
        switch (difficultyType)
        {
            case DifficultType.Easy:
                enemySpawnData.WaitToSpawn = 30;
                count = 1;
                break;
            case DifficultType.Medium:
                enemySpawnData.WaitToSpawn = 27;
                count = 2;
                break;
            case DifficultType.Hard:
                enemySpawnData.WaitToSpawn = 25;
                count = 3;
                break;
            case DifficultType.Expert:
                enemySpawnData.WaitToSpawn = 22;
                count = 4;
                break;
            case DifficultType.Veteran:
                enemySpawnData.WaitToSpawn = 18;
                count = 5;
                break;
            case DifficultType.Turkey:
                enemySpawnData.WaitToSpawn = 15;
                count = 6;
                break;
            default:
                break;
        }

        DifficultyLevel = count;
    }


}
