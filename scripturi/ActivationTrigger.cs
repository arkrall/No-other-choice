using UnityEngine;

public class ActivationTrigger : MonoBehaviour
{
    public GameObject objectA;
    public GameObject objectB;
    public GameObject finalObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger, activating all objects.");

            if (objectA != null) objectA.SetActive(true);
            if (objectB != null) objectB.SetActive(true);
            if (finalObject != null) finalObject.SetActive(true);
        }
    }
}
