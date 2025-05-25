using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenaScrisoare : MonoBehaviour
{
    public GameObject noteImage;

    void Start()
    {
        // Se activează doar dacă suntem în scena HouseInside
        if (SceneManager.GetActiveScene().name != "HouseInside")
        {
            noteImage.SetActive(false);
        }
    }

    void Update()
    {
        // În HouseInside, dacă apăsăm Escape, ascundem nota
        if (SceneManager.GetActiveScene().name == "HouseInside" && noteImage.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            noteImage.SetActive(false);
            Time.timeScale = 1f; // Repornim jocul dacă l-am oprit
        }
    }

    public void ShowNote()
    {
        noteImage.SetActive(true);
        Time.timeScale = 0f; // Oprește jocul cât timp e afișată poza
    }
}