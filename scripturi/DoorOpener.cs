using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public string requiredItemName = "rust_key";
    public float openAngle = 90f;
    public float openSpeed = 300f;

    private bool isPlayerNear = false;
    private bool doorOpened = false;
    private Transform doorTransform;

    void Start()
    {
        doorTransform = transform.parent;
        if (doorTransform == null)
        {
            Debug.LogError("DoorOpener: Nu există un părinte pentru collider. Atașează scriptul pe colliderul child al ușii.");
        }
    }

    void Update()
    {
        if (!isPlayerNear || doorOpened) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player == null)
            {
                Debug.LogWarning("DoorOpener: Nu am găsit player-ul.");
                return;
            }

            PickupSystem pickup = player.GetComponent<PickupSystem>();
            if (pickup == null)
            {
                Debug.LogWarning("DoorOpener: Player-ul nu are PickupSystem.");
                return;
            }

            GameObject heldItem = pickup.GetHeldItem();
            if (heldItem == null)
            {
                Debug.Log("DoorOpener: Jucătorul nu ține nimic în mână.");
                return;
            }

            Debug.Log($"DoorOpener: Jucătorul ține în mână {heldItem.name}");

            if (heldItem.name.ToLower().Contains(requiredItemName.ToLower()))
            {
                Debug.Log("DoorOpener: Cheia este corectă, deschid ușa...");
                OpenDoor();

                pickup.DropHeldItem();
                Destroy(heldItem);
                doorOpened = true;
            }
            else
            {
                Debug.Log("DoorOpener: Obiectul ținut nu este cheia potrivită.");
            }
        }
    }

    private void OpenDoor()
    {
        if (doorTransform == null) return;

        Vector3 newRotation = doorTransform.eulerAngles + new Vector3(0, openAngle, 0);
        doorTransform.eulerAngles = newRotation;

        Debug.Log("DoorOpener: Ușa a fost rotită.");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            Debug.Log("DoorOpener: Playerul a intrat în trigger.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            Debug.Log("DoorOpener: Playerul a ieșit din trigger.");
        }
    }
}
