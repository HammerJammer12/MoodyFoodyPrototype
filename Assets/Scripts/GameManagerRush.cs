using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManagerRush : MonoBehaviour
{
    public TextMeshProUGUI timerText;
   public TextMeshProUGUI targetEmotionText;  // Single text object for dynamic target emotions
    public PersonRush personRush;  // Reference to the PersonRush script

    private float timer = 20f;
    private bool isGameActive = true;
    private string currentTargetEmotion;
    

    void Start()
    {
        //Set text colors to red initially
        SetTextColorRed(timerText);
        SetTextColorRed(targetEmotionText);

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
                Debug.Log("Time's up!");
                // Handle end-game logic if necessary
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

        UpdateTargetEmotionText(targetEmotion);
        
    }

    public void ResetRound()
    {
        // if (currentTargetEmotion == "Satisfaction")
        // {
        //     StartNewRound("Disgust");
        // }
        // if (currentTargetEmotion == "Disgust")
        // {
        //     Debug.Log("You won!");
        //     // Add additional logic if needed
        // }
    }


    private void UpdateTargetEmotionText(string targetEmotion)
    {
        
        targetEmotionText.text = "Target emotion: " + targetEmotion;
        targetEmotionText.gameObject.SetActive(true);
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
