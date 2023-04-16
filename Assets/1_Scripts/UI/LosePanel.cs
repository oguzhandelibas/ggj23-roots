using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePanel : MonoBehaviour
{
    public void _TryAgain()
    {
        SceneManager.LoadScene(2);
    }

    public void _TurnBackMenu()
    {
        SceneManager.LoadScene(1);
    }
}
