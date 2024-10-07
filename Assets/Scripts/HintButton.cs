using UnityEngine;

public class HintButton : MonoBehaviour
{
    public GameObject hintPanel; // Reference to the Hint Panel

    public void ShowHint()
    {
        if (hintPanel != null)
        {
            hintPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("Hint Panel is not assigned in the inspector.");
        }
    }
}
