using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    //public TextMeshProUGUI timerText;
   // public TextMeshProUGUI targetEmotionText;  // Single text object for dynamic target emotions
    public TextMeshProUGUI moneyDisplayText;
    //public PersonRush personRush;  // Reference to the PersonRush script

    private float timer = 20f;
    private bool isGameActive = true;
    private string currentTargetEmotion;
    public static GameManager instance;

    public int money;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        // Set text colors to red initially
        //SetTextColorRed(timerText);
        //SetTextColorRed(targetEmotionText);

        //start with money at 0
        money = 0;

        //StartNewRound("Satisfaction");
    }

    void Update()
    {
        /*
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
        */
        //update money text
        moneyDisplayText.text = "Money: " + money.ToString();
    }


    public void StartNewRound(string targetEmotion)
    {/*
        timer = 20f;
        isGameActive = true;
        timerText.gameObject.SetActive(true);

        currentTargetEmotion = targetEmotion;
        personRush.SetTargetEmotion(targetEmotion);

        UpdateTargetEmotionText(targetEmotion);
        */
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

    public void AddMoney(int amount)
    {
        money += amount;
        if (money < 0)
        {
            money = 0;
        }
    }

/*
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
    */
}
