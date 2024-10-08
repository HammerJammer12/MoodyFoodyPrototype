using UnityEngine;
using TMPro;
using System.Collections.Generic;


public class PersonRush : MonoBehaviour
{
    public TextMeshProUGUI satisfactionText;
    public TextMeshProUGUI disgustText;
    public TextMeshProUGUI congratulationsText; // Reference to the "Congratulations" text
    public TextMeshProUGUI timerText; // Reference to the timer text

    private string currentEmotion = "None";
    private string targetEmotion = "None";
    private List<string> foodsFed = new List<string>();

    public void SetEmotion(string emotion)
    {
        currentEmotion = emotion;
        switch (emotion)
        {
            case "Satisfaction":
                satisfactionText.gameObject.SetActive(true);
                if (timerText != null)
                {
                    Destroy(timerText.gameObject); // Destroy the timer text when satisfaction is reached
                }
                Invoke(nameof(DestroySatisfactionText), 2f); // Destroy satisfaction text after 2 seconds
                break;
            case "Disgust":
                disgustText.gameObject.SetActive(true);
                Invoke(nameof(DestroyDisgustText), 2f); // Destroy disgust text after 2 seconds
                break;
        }
    }

    public void SetTargetEmotion(string emotion)
    {
        targetEmotion = emotion;
    }

    public string GetTargetEmotion()
    {
        return targetEmotion;
    }

    public void ResetEmotion()
    {
        currentEmotion = "None";
        foodsFed.Clear();
    }

    public void AddFood(string foodType)
    {
        foodsFed.Add(foodType);
        Debug.Log($"Person has been fed {foodsFed.Count} foods. Food added: {foodType}");
    }

    public bool HasReachedSatisfaction()
    {
        int appleCount = foodsFed.FindAll(f => f == "Apple").Count;
        int cakeCount = foodsFed.FindAll(f => f == "Cake").Count;
        Debug.Log($"Checking satisfaction: {appleCount} Apples and {cakeCount} Cakes fed.");
        return appleCount == 2 && cakeCount == 2;
    }

    private void DestroySatisfactionText()
    {
        satisfactionText.gameObject.SetActive(false);
        ShowCongratulations(); // Display the congratulations text after satisfaction text is destroyed
    }

    private void ShowCongratulations()
    {
        congratulationsText.gameObject.SetActive(true); // Show the "Congratulations" text
    }

    private void DestroyDisgustText()
    {
        disgustText.gameObject.SetActive(false);
    }
}
