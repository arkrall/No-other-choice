using UnityEngine;

public class KeyPickupTrigger : MonoBehaviour
{
    private bool playerIsNear = false;
    private bool keyTaken = false;

    public GameObject keyObject;          // Obiectul cheii (rust_key)
    public Transform handPosition;        // Referința la mâna jucătorului unde va sta cheia

    public GameObject obiectDeDezactivat; // obiectul din scena care se dezactivează când iei cheia
    public TriggerActivator triggerActivator;

    void Update()
    {
        if (playerIsNear && Input.GetKeyDown(KeyCode.E) && !keyTaken)
        {
            Debug.Log("E pressed near key!");
            PickupKey();
        }
    }

    private void PickupKey()
    {
        Debug.Log("Key picked up!");

        keyTaken = true;

        // face cheia copilul mâinii
        keyObject.transform.SetParent(handPosition);
        keyObject.transform.localPosition = Vector3.zero;
        keyObject.transform.localRotation = Quaternion.identity;

        Rigidbody rb = keyObject.GetComponent<Rigidbody>();
        if (rb != null) rb.isKinematic = true;

        Collider col = keyObject.GetComponent<Collider>();
        if (col != null) col.enabled = false;

        // dezactivează triggerul ca să nu mai poată fi luată iar
        gameObject.SetActive(false);

        // dezactivează obiectul specific din scena
        if (obiectDeDezactivat != null)
        {
            obiectDeDezactivat.SetActive(false);
            Debug.Log("Obiectul specific a fost dezactivat!");
        }

        if (triggerActivator != null)
        {
            triggerActivator.SetKeyTaken();
        }
    }

    public bool GetKeyTaken()
    {
        return keyTaken;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered key trigger zone");
            playerIsNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player left key trigger zone");
            playerIsNear = false;
        }
    }
}
