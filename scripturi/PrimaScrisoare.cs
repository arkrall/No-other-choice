using UnityEngine;
using TMPro;

public class PrimaScriosoare : MonoBehaviour
{
    public GameObject PrimaScrisoareUI;         // UI-ul cu poza scrisorii
    public TextMeshProUGUI hintText;            // Textul "Press E to inspect"

    private bool isPlayerNear = false;

    void Start()
    {
        PrimaScrisoareUI.SetActive(false);      // Ascundem scrisoarea la început
        hintText.gameObject.SetActive(false);   // Ascundem hint-ul la început
    }

    void Update()
    {
        if (isPlayerNear)
        {
            hintText.gameObject.SetActive(true);   // Afișează "Press E to inspect"

            if (Input.GetKeyDown(KeyCode.E))
            {
                PrimaScrisoareUI.SetActive(true);  // Arată imaginea scrisorii
                Time.timeScale = 0f;               // Pauză joc
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                hintText.gameObject.SetActive(false); // Ascunde hint-ul când e deschis
            }
        }

        // Dacă imaginea e pe ecran și jucătorul apasă ESC
        if (PrimaScrisoareUI.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            PrimaScrisoareUI.SetActive(false);
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            hintText.gameObject.SetActive(false); // Ascunde hint-ul când pleci
        }
    }
}
