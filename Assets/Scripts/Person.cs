using UnityEngine;
using TMPro;  // Add this namespace to use TextMeshPro

public class Person : MonoBehaviour
{
    public TextMeshProUGUI happyText;  // Reference to the TextMeshProUGUI component
    public TextMeshProUGUI angryText;  // Reference to the TextMeshProUGUI component

    private string currentState = "neutral";  // Track the person's emotional state

    // Method to make the person happy
    public void SetHappy()
    {
        currentState = "happy";
        Debug.Log("Person is happy!");

        // Enable happy text and disable angry text
        happyText.gameObject.SetActive(true);
        angryText.gameObject.SetActive(false);

        // Disable the happy text after 2 seconds without destroying it
        Invoke(nameof(DisableHappyText), 5f);
    }

    // Method to make the person angry
    public void SetAngry()
    {
        currentState = "angry";
        Debug.Log("Person is angry!");

        // Enable angry text and disable happy text
        angryText.gameObject.SetActive(true);
        happyText.gameObject.SetActive(false);

        // Disable the angry text after 2 seconds without destroying it
        Invoke(nameof(DisableAngryText), 5f);
    }

    // Method to disable happy text
    private void DisableHappyText()
    {
        happyText.gameObject.SetActive(false);
    }

    // Method to disable angry text
    private void DisableAngryText()
    {
        angryText.gameObject.SetActive(false);
    }
}
