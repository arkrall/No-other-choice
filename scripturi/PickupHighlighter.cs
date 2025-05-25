using UnityEngine;

public class PickupHighlighter : MonoBehaviour
{
    public Color highlightColor = Color.yellow;
    private Color originalColor;
    private Renderer parentRenderer;

    private bool isPickedUp = false;

    void Start()
    {
        parentRenderer = transform.parent.GetComponent<Renderer>();
        if (parentRenderer != null)
        {
            parentRenderer.material = new Material(parentRenderer.material);
            originalColor = parentRenderer.material.color;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isPickedUp)
        {
            SetHighlight(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !isPickedUp)
        {
            SetHighlight(false);
        }
    }

    // Apelează asta când iei cheia în mână
    public void PickUp()
    {
        isPickedUp = true;
        ClearHighlight();  // Oprim glow-ul când este luată
    }

    // Metodă publică ca să oprești glow-ul explicit
    public void ClearHighlight()
    {
        SetHighlight(false);
    }

    private void SetHighlight(bool highlight)
    {
        if (parentRenderer == null)
            return;

        if (highlight)
        {
            parentRenderer.material.EnableKeyword("_EMISSION");
            parentRenderer.material.SetColor("_EmissionColor", highlightColor);
        }
        else
        {
            parentRenderer.material.SetColor("_EmissionColor", Color.black);
            parentRenderer.material.DisableKeyword("_EMISSION");
        }
    }
}
