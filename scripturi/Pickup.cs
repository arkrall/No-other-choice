using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float pickUpRange = 3f;
    public Transform holdPoint; // Un empty object în fa?a camerei
    private GameObject heldObject;
    private Rigidbody heldRb;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null)
            {
                TryPickUp();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (heldObject != null)
            {
                DropObject();
            }
        }
    }

    void TryPickUp()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, pickUpRange))
        {
            if (hit.collider.CompareTag("Pickup"))
            {
                heldObject = hit.collider.gameObject;
                heldRb = heldObject.GetComponent<Rigidbody>();

                if (heldRb != null)
                {
                    heldRb.isKinematic = true;
                    heldObject.transform.position = holdPoint.position;
                    heldObject.transform.rotation = holdPoint.rotation;
                    heldObject.transform.SetParent(holdPoint);
                }
            }
        }
    }

    void DropObject()
    {
        heldObject.transform.SetParent(null);
        heldRb.isKinematic = false;
        heldRb = null;
        heldObject = null;
    }
}