using UnityEngine;
using TMPro;
using UnityEngine.UI; // Required for Button component
using System.Collections.Generic;

public class PersonRush : MonoBehaviour
{
    public Button satisfactionButton;

    public Button congratulationsButton; // Reference to the "Congratulations" button
    public Button timerButton; // Reference to the timer button

    private string currentEmotion = "None";
    private string targetEmotion = "None";
    private List<string> foodsFed = new List<string>();

    public void SetEmotion(string emotion)
    {
        currentEmotion = emotion;
        switch (emotion)
        {
            case "Satisfaction":
                satisfactionButton.gameObject.SetActive(true);
                Debug.Log("setting emotion");
                if (timerButton != null)
                {
                    
                    Destroy(timerButton.gameObject); // Destroy the timer button when satisfaction is reached
                    Debug.Log("destroy timer");
                }
                Invoke(nameof(DestroySatisfactionButton), 2f); // Destroy satisfaction button after 2 seconds
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

    private void DestroySatisfactionButton()
    {
        satisfactionButton.gameObject.SetActive(false);
        Debug.Log("set to false");
        ShowCongratulations(); // Display the congratulations button after satisfaction button is destroyed
    }

    private void ShowCongratulations()
    {
        congratulationsButton.gameObject.SetActive(true); // Show the "Congratulations" button
        Debug.Log("set congrats");
    }


}
