using UnityEngine;

public class PickupSystem : MonoBehaviour
{
    public Transform handPosition;
    private GameObject heldItem = null;

    public float pickupRange = 2f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldItem == null)
            {
                TryPickup();
            }
        }
    }

    void TryPickup()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position + transform.forward * pickupRange, 1f);

        Debug.Log($"Found {hits.Length} colliders near player.");
        foreach (Collider col in hits)
        {
            Debug.Log("Collider found: " + col.gameObject.name + ", Tag: " + col.gameObject.tag);

            GameObject candidate = col.gameObject;

            if (!candidate.CompareTag("Pickup") && candidate.transform.parent != null)
            {
                candidate = candidate.transform.parent.gameObject;
                Debug.Log("Candidate moved to parent: " + candidate.name);
            }

            if (candidate.CompareTag("Pickup"))
            {
                Debug.Log("Pickup candidate found: " + candidate.name);
                heldItem = candidate;

                Rigidbody rb = heldItem.GetComponent<Rigidbody>();
                if (rb != null) rb.isKinematic = true;

                Collider c = heldItem.GetComponent<Collider>();
                if (c != null) c.enabled = false;

                heldItem.transform.SetParent(handPosition);
                heldItem.transform.localPosition = Vector3.zero;
                heldItem.transform.localRotation = Quaternion.identity;

                PickupHighlighter highlighter = heldItem.GetComponentInChildren<PickupHighlighter>();
                if (highlighter != null)
                {
                    highlighter.PickUp();
                }
                break;
            }
        }
    }

    public GameObject GetHeldItem()
    {
        return heldItem;
    }
    public void DropHeldItem()
    {
        if (heldItem != null)
        {
            Rigidbody rb = heldItem.GetComponent<Rigidbody>();
            if (rb != null) rb.isKinematic = false;

            Collider c = heldItem.GetComponent<Collider>();
            if (c != null) c.enabled = true;

            heldItem.transform.SetParent(null);
            heldItem = null;
        }
    }

}