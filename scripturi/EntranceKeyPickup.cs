using UnityEngine;

public class EntranceKeyPickup : MonoBehaviour
{
    private bool playerIsNear = false;

    public GameObject keyObject;       // cheia de luat (ex: entrance_key)
    public Transform handPosition;     // locul din mâna jucătorului

    void Update()
    {
        if (playerIsNear && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E pressed near ENTRANCE key!");
            PickupKey();
        }
    }

    private void PickupKey()
    {
        Debug.Log("Entrance key picked up!");

        // atașează cheia în mână
        keyObject.transform.SetParent(handPosition);
        keyObject.transform.localPosition = Vector3.zero;
        keyObject.transform.localRotation = Quaternion.identity;

        Rigidbody rb = keyObject.GetComponent<Rigidbody>();
        if (rb != null) rb.isKinematic = true;

        Collider col = keyObject.GetComponent<Collider>();
        if (col != null) col.enabled = false;

        // dezactivează triggerul după pickup
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered ENTRANCE key trigger zone");
            playerIsNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player left ENTRANCE key trigger zone");
            playerIsNear = false;
        }
    }
}
