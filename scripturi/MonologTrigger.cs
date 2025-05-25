using UnityEngine;

public class MonologTrigger : MonoBehaviour
{
    public MonologSystem monologSystem;
    [TextArea]
    public string[] linesToSay;
    public GameObject[] triggersToEnableAfter;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;
        if (other.CompareTag("Player"))
        {
            MoveInside playerScript = other.GetComponent<MoveInside>();
            if (playerScript != null && monologSystem != null)
            {
                hasTriggered = true;
                monologSystem.ShowMonolog(linesToSay, playerScript);
                Destroy(gameObject); // distruge triggerul după ce e folosit
            }
        }
        if (triggersToEnableAfter != null)
        {
            foreach (GameObject go in triggersToEnableAfter)
                if (go != null) go.SetActive(true);
        }
    }
}
