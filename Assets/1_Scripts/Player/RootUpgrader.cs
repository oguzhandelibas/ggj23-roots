using UnityEngine;

public class RootUpgrader : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (ScoreManager.Instance.AvailableUpgradeCount > 0)
        {
            ScoreManager.Instance.UpgradeRootSpeed();
        }
    }
}