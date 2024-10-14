using UnityEngine;
using UnityEngine.UI;

public class SatisfactionBar : MonoBehaviour
{
    public Slider satisfactionSlider; // Reference to the UI slider
    private float currentSatisfaction = 30f; // Initial satisfaction percentage

    void Start()
    {
        // Set the slider value to the current satisfaction
        if (satisfactionSlider != null)
        {
            satisfactionSlider.value = currentSatisfaction;
        }
        else
        {
            Debug.LogError("Satisfaction slider is not assigned.");
        }
    }

    // Method to increase satisfaction by a certain percentage
    public void IncreaseSatisfaction(float amount)
    {
        currentSatisfaction = Mathf.Clamp(currentSatisfaction + amount, 0, 100); // Clamp between 0 and 100
        if (satisfactionSlider != null)
        {
            satisfactionSlider.value = currentSatisfaction; // Update the slider UI
        }

        Debug.Log($"Satisfaction increased by {amount}%. Current satisfaction: {currentSatisfaction}%");
    }

    // Method to set the satisfaction slider value (used when loading the scene)
    public void SetSatisfaction(float satisfaction)
    {
        currentSatisfaction = Mathf.Clamp(satisfaction, 0, 100);
        if (satisfactionSlider != null)
        {
            satisfactionSlider.value = currentSatisfaction;
        }
    }
}
