using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class SceneBasedAudio : MonoBehaviour
{
    public string targetSceneName = "NumeScena"; // ← înlocuiește cu numele exact al scenei tale

    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == targetSceneName)
        {
            GetComponent<AudioSource>().Play();
        }
        else
        {
            GetComponent<AudioSource>().Stop();
        }
    }
}
