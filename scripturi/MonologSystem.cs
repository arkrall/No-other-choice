using System.Collections;
using UnityEngine;
using TMPro;

public class MonologSystem : MonoBehaviour
{
    public TextMeshProUGUI monologTextUI;
    public float typingSpeed = 0.05f;

    private Coroutine typingCoroutine;
    private MoveInside moveScript;

    public void ShowMonolog(string[] lines, MoveInside player)
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        moveScript = player;
        if (moveScript != null)
            moveScript.EnableMovement(false);

        typingCoroutine = StartCoroutine(TypeLines(lines));
    }

    private IEnumerator TypeLines(string[] lines)
    {
        monologTextUI.text = "";

        foreach (string line in lines)
        {
            yield return StartCoroutine(TypeLine(line));
            yield return new WaitForSeconds(1f);
        }

        monologTextUI.text = "";

        if (moveScript != null)
            moveScript.EnableMovement(true);
    }

    private IEnumerator TypeLine(string line)
    {
        monologTextUI.text = "";

        foreach (char c in line)
        {
            monologTextUI.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void StopMonolog()
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        monologTextUI.text = "";

        if (moveScript != null)
            moveScript.EnableMovement(true);
    }
}
