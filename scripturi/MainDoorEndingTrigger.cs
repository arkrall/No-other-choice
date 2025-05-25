using UnityEngine;
using UnityEngine.SceneManagement; // doar dacă vrei să schimbi scena

public class MainDoorEndingTrigger : MonoBehaviour
{
    public string keyName = "entrance_key"; // numele obiectului cheii din ierarhie
    public Transform playerHand;            // locul unde e ținut obiectul
    public string endingSceneName = "EndingScene"; // sau alt mod de cutscene

    private bool playerIsNear = false;

    void Update()
    {
        if (playerIsNear && Input.GetKeyDown(KeyCode.E))
        {
            if (playerHand.childCount > 0 && playerHand.GetChild(0).name == keyName)
            {
                Debug.Log("Jucătorul are cheia de la intrare! Pornesc ending-ul.");

                // Dacă vrei să schimbi scena:
                SceneManager.LoadScene(endingSceneName);

                // SAU dacă ai un cutscene manager:
                // CutsceneManager.Instance.StartEnding();

                // SAU activezi o animație:
                // animator.SetTrigger("StartCutscene");
            }
            else
            {
                Debug.Log("Jucătorul NU are cheia corectă.");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = true;
            Debug.Log("Jucătorul e lângă ușa principală.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = false;
            Debug.Log("Jucătorul a plecat de lângă ușa principală.");
        }
    }
}
