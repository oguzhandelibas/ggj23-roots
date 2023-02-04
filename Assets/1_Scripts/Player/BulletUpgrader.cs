using UnityEngine;

public class BulletUpgrader : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (ScoreManager.Instance.AvailableUpgradeCount > 0)
        {
            ScoreManager.Instance.UpgradeBulletPower();
        }
    }
}