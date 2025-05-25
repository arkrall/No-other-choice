using UnityEngine;
using UnityEngine.SceneManagement;

public class BadEndingTrigger : MonoBehaviour
{
    public KeyPickupTrigger basementKeyPickup; // referință la scriptul cheii

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player în trigger BadEnding");

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E apăsat în trigger BadEnding");

                if (basementKeyPickup != null && basementKeyPickup.GetKeyTaken())
                {
                    Debug.Log("Cheia e luată, schimb scena...");
                    SceneManager.LoadScene("BadEnding");
                }
                else
                {
                    Debug.Log("Cheia nu e luată încă.");
                }
            }
        }
    }

}
