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
            timer -= Time.deltaTime;
            timerText.text = "Timer: " + Mathf.Ceil(timer).ToString();

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
        timerText.gameObject.SetActive(true);

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

    private void SetTextColorRed(TextMeshProUGUI textComponent)
    {
        if (textComponent != null)
        {
            textComponent.color = Color.red;
        }
        else
        {
            Debug.LogError("TextMeshProUGUI component not assigned!");
        }
    }
    
}
