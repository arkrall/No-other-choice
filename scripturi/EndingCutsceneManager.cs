using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class EndingCutsceneManager : MonoBehaviour
{
    [Tooltip("Numele scenei care se încarcă după cutscene")]
    public string nextSceneName = "MainMenu";

    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        if (videoPlayer == null)
        {
            Debug.LogError("VideoPlayer component missing on this GameObject!");
            return;
        }

        videoPlayer.playOnAwake = false;
        videoPlayer.Stop();

        videoPlayer.Play();
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            LoadNextScene();
        }
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("Next scene name is empty, cannot load next scene.");
        }
    }
}
