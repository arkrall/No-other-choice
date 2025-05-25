using UnityEngine;

public class TriggerActivator : MonoBehaviour
{
    public GameObject[] objectsToActivate;
    private bool keyTaken = false;

    public void SetKeyTaken()
    {
        keyTaken = true;
        Debug.Log("Cheia a fost luată, trigger activat!");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ceva a intrat în trigger: " + other.name);

        if (!keyTaken)
        {
            Debug.Log("Dar cheia NU a fost luată încă!");
            return;
        }

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player a intrat în trigger și cheia e luată! Activez obiectele.");
            foreach (GameObject obj in objectsToActivate)
            {
                obj.SetActive(true);
            }

            gameObject.SetActive(false); // opțional, dezactivezi triggerul după ce s-a folosit
        }
    }
}
