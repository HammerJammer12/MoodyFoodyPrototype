using UnityEngine;
using TMPro; // Make sure you have the TextMeshPro namespace

public class MoneyTracker : MonoBehaviour
{
    public TextMeshProUGUI moneyText; // Reference to the TextMeshProUGUI component that displays money

    void Start()
    {
        // Ensure moneyText is assigned in the Unity Inspector
        if (moneyText == null)
        {
            Debug.LogError("Money TextMeshPro is not assigned in MoneyTracker.");
            return;
        }

        // Update the money text when the scene loads
        UpdateMoneyDisplay();
    }

    // Function to update the money display
    private void UpdateMoneyDisplay()
    {
        if (moneyText != null)
        {
            // Set the TextMeshPro text to reflect the current money amount from PlayerStatusManager
            moneyText.text = "$" + PlayerStatusManager.currentMoney.ToString();
        }
        else
        {
            Debug.LogError("Money TextMeshPro is missing.");
        }
    }

    // Optionally, you can create a public method that can be called if the money is updated dynamically in this scene
    public void RefreshMoneyDisplay()
    {
        UpdateMoneyDisplay();
    }
}
