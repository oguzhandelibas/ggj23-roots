using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        StartCoroutine(WaitForVideoToEnd());
    }

    IEnumerator WaitForVideoToEnd()
    {
        yield return new WaitForSeconds((float)videoPlayer.length);
        yield return new WaitUntil(() => !videoPlayer.isPlaying);
        SceneManager.LoadScene("5_Scenes/Main/GameScene");
    }
}
