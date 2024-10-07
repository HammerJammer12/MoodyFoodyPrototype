using UnityEngine;
using TMPro;

public class GameManagerRush : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI targetEmotionText;  // Single text object for dynamic target emotions
    public PersonRush personRush;  // Reference to the PersonRush script
    public GameObject applePrefab;  // Prefab for the Apple
    public GameObject cakePrefab;  // Prefab for the Cake

    private float timer = 10f;
    private bool isGameActive = true;
    private string currentTargetEmotion;

    void Start()
    {
        // Start the first round with the "Satisfaction" target emotion
        StartNewRound("Satisfaction");
    }

    void Update()
    {
        if (isGameActive)
        {
            // Countdown the timer
            timer -= Time.deltaTime;
            timerText.text = "Timer: " + Mathf.Ceil(timer).ToString();

            if (timer <= 0)
            {
                isGameActive = false;
                timer = 0;
                Debug.Log("Time's up!");
                // Handle what happens if the player doesn't reach the target emotion in time
            }
        }
    }

    public void StartNewRound(string targetEmotion)
    {
        // Set the timer and activate the timer text
        timer = 10f;
        isGameActive = true;
        timerText.gameObject.SetActive(true);

        // Set the new target emotion
        currentTargetEmotion = targetEmotion;
        personRush.SetTargetEmotion(targetEmotion);

        // Update and show the target emotion text dynamically
        UpdateTargetEmotionText(targetEmotion);

        // Spawn the food items in the scene
        SpawnFoodItems();
    }

    public void ResetRound()
    {
        // Change the target emotion and reset the round
        if (currentTargetEmotion == "Satisfaction")
        {
            StartNewRound("Disgust");
        }
        else if (currentTargetEmotion == "Disgust")
        {
            Debug.Log("You won!");
            // Handle additional win logic if needed
        }
    }

    private void UpdateTargetEmotionText(string targetEmotion)
    {
        // Update the text to display the target emotion with the prefix "Target: "
        targetEmotionText.text = "Target: " + targetEmotion;
        targetEmotionText.gameObject.SetActive(true);
    }

    private void SpawnFoodItems()
    {
        // Define positions where the food items should be spawned
        Vector3 applePosition = new Vector3(-2, 1, 0);
        Vector3 cakePosition = new Vector3(2, 1, 0);

        // Instantiate the apple prefab
        GameObject apple = Instantiate(applePrefab, applePosition, Quaternion.identity);
        apple.name = "Apple";

        // Instantiate the cake prefab
        GameObject cake = Instantiate(cakePrefab, cakePosition, Quaternion.identity);
        cake.name = "Cake";
    }
}
