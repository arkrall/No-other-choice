using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    void Start()
    {
        // Asigurăm că în meniu cursorul este vizibil și deblocat
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("cutscene"); // Prima scenă după meniu
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit game!"); // Vizibil doar în editor
    }
}