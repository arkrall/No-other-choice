using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CutsceneDoor : MonoBehaviour
{
    public string nextSceneName = "GameScene";
    private VideoPlayer videoPlayer;
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "CutSceneIntrare")
        {
            videoPlayer = GetComponent<VideoPlayer>();
            videoPlayer.Play();
            videoPlayer.loopPointReached += OnVideoFinished;
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            LoadNextScene();
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        LoadNextScene();
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}