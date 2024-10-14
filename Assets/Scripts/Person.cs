using UnityEngine;
using TMPro;  

public class Person : MonoBehaviour
{
    public TextMeshProUGUI happyText;
    public TextMeshProUGUI angryText;  

    private enum EmotionalState { Neutral, Happy, Angry }
    private EmotionalState currentState = EmotionalState.Neutral;  // Track the person's emotional state
    private float displayDuration = 5f;  // Duration for which the text will be displayed

    // Method to make the person happy
    public void SetHappy()
    {
        currentState = EmotionalState.Happy;
        Debug.Log("Person is happy!");

        // Enable happy text and disable angry text
        happyText.gameObject.SetActive(true);
        angryText.gameObject.SetActive(false);

        // Disable the happy text after a set duration without destroying it
        Invoke(nameof(DisableHappyText), displayDuration);
    }

    // Method to make the person angry
    public void SetAngry()
    {
        currentState = EmotionalState.Angry;
        Debug.Log("Person is angry!");

        // Enable angry text and disable happy text
        angryText.gameObject.SetActive(true);
        happyText.gameObject.SetActive(false);

        // Disable the angry text after a set duration without destroying it
        Invoke(nameof(DisableAngryText), displayDuration);
    }

    // Method to disable happy text
    private void DisableHappyText()
    {
        if (currentState == EmotionalState.Happy)
        {
            happyText.gameObject.SetActive(false);
            currentState = EmotionalState.Neutral;
        }
    }

    // Method to disable angry text
    private void DisableAngryText()
    {
        if (currentState == EmotionalState.Angry)
        {
            angryText.gameObject.SetActive(false);
            currentState = EmotionalState.Neutral;
        }
    }
}
