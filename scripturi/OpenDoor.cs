using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DoorSceneChanger : MonoBehaviour
{
    public string nextSceneName = "NextScene";
    public GameObject interactionHint;

    private bool isPlayerNearby = false;

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            if (interactionHint != null)
                interactionHint.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            if (interactionHint != null)
                interactionHint.SetActive(false);
        }
    }
}