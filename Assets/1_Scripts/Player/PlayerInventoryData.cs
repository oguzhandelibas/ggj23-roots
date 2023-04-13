using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Player/PlayerInventory")]
public class PlayerInventory : MonoBehaviour
{
    #region PowerUp

    [SerializeField] private int medkitCount = 0;
    [SerializeField] private int strengthCount = 0;
    [SerializeField] private int healthReductionCount = 0;
    [SerializeField] private int coinMultiplierCount = 0;

    public int Medkit { get => medkitCount; set => medkitCount = value; }
    public int StrengtCount { get => strengthCount; set => strengthCount = value; }
    public int HealthReduction { get => healthReductionCount; set => healthReductionCount = value; }
    public int CoinMultiplier { get => coinMultiplierCount; set => coinMultiplierCount = value; }
    #endregion
}
