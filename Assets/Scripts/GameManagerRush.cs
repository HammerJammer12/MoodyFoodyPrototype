using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManagerRush : MonoBehaviour
{
    public Button timerButton;
    public Button targetEmotionButton; // Single button for dynamic target emotions
    public PersonRush personRush; // Reference to the PersonRush script

    private float timer = 20f;
    private bool isGameActive = true;
    private string currentTargetEmotion;

    void Start()
    {
        // Set initial text and color for the timer button
        SetButtonText(timerButton, "Timer: 20s");
        SetButtonTextColorRed(timerButton);
        
        StartNewRound("Satisfaction");
    }

    void Update()
    {
        if (isGameActive)
        {
            // Update the timer
            timer -= Time.deltaTime;

            if (timerButton != null && timerButton.gameObject.activeInHierarchy)
            {
                // Update the button text with the remaining time
                SetButtonText(timerButton, "Timer: " + Mathf.Ceil(timer).ToString() + "s");

                if (timer <= 0)
                {
                    isGameActive = false;
                    timer = 0;
                    SetButtonText(timerButton, "Timer: 0s");
                    Debug.Log("Time's up!");
                    // Handle end-game logic if necessary
                }
            }


        }
    }

    public void StartNewRound(string targetEmotion)
    {
        timer = 20f;
        isGameActive = true;
        SetButtonText(timerButton, "Timer: 20s");
        timerButton.gameObject.SetActive(true);

        currentTargetEmotion = targetEmotion;
        personRush.SetTargetEmotion(targetEmotion);

        UpdateTargetEmotionButton(targetEmotion);
    }

    public void ResetRound()
    {
        // Additional logic can be added here
    }

    private void UpdateTargetEmotionButton(string targetEmotion)
    {
        SetButtonText(targetEmotionButton, "Target emotion: " + targetEmotion);
        targetEmotionButton.gameObject.SetActive(true);
    }

    private void SetButtonText(Button button, string text)
    {
        if (button != null)
        {
            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null)
            {
                buttonText.text = text;
            }
            else
            {
                Debug.LogError("Button does not contain a TextMeshProUGUI component!");
            }
        }
        else
        {
            Debug.LogError("Button component not assigned!");
        }
    }

    private void SetButtonTextColorRed(Button button)
    {
        if (button != null)
        {
            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null)
            {
                buttonText.color = Color.red;
            }
            else
            {
                Debug.LogError("Button does not contain a TextMeshProUGUI component!");
            }
        }
        else
        {
            Debug.LogError("Button component not assigned!");
        }
    }
}
