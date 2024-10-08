using UnityEngine;

public class CloseHintButton : MonoBehaviour
{
    public GameObject hintPanel; // Reference to the Hint Panel

    public void CloseHint() // Make sure this is public
    {
        if (hintPanel != null)
        {
            hintPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Hint Panel is not assigned in the inspector.");
        }
    }
}
