using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class PlayerStatusManager : MonoBehaviour
{
    public TextMeshProUGUI statusText; // Reference to the Status button's TextMeshProUGUI component
    public TextMeshProUGUI moneyText;  // Reference to the money TextMeshProUGUI component
    public Button wonButton;           // Reference to the "Won" button
    public SatisfactionBar satisfactionBar; // Reference to the SatisfactionBar script

    // Static variables to persist across scenes
    public static int currentMoney = 0;
    public static float currentSatisfaction = 30f; // Initial satisfaction is 30%
    public static string currentRequest = "coffee"; // Initial request
    public static bool fedCoffee = false;
    public static bool fedCoffeeWithSugar = false;
    public static bool fedCoffeeWithCream = false;
    public static bool fedMatchaMilk = false;
    public static bool fedMatchaMilkHoney = false;

    void Start()
    {
        // Restore status and game state
        UpdateStatusMessage();
        UpdateMoneyText();

        if (satisfactionBar != null)
        {
            satisfactionBar.SetSatisfaction(currentSatisfaction); // Ensure satisfaction bar starts with correct value
        }

        // Make sure the "Won" button is initially inactive if the game isn't won yet
        if (wonButton != null)
        {
            wonButton.gameObject.SetActive(fedMatchaMilkHoney); // Show the Won button only if the player has won
            StartCoroutine(DestroyWonButtonAfterDelay(2f)); // Destroy after 2 seconds
        }
        else
        {
            Debug.LogWarning("Won button is not assigned in the PlayerStatusManager.");
        }
    }

    public void SetStatus(string newStatus)
    {
        statusText.text = newStatus;
    }

    public void UpdateRequest(string newRequest)
    {
        currentRequest = newRequest;
    }

    public void FeedCoffee()
    {
        SetStatus("Nice!");
        Debug.Log("Feed coffee. now happy. about to increase satisfaction.");

        if (satisfactionBar != null && !fedCoffee)
        {
            satisfactionBar.IncreaseSatisfaction(10f);
            currentSatisfaction = Mathf.Clamp(currentSatisfaction + 10f, 0, 100); // Update static satisfaction
        }

        if (!fedCoffee)
        {
            currentMoney += 5;
            UpdateMoneyText();
        }

        fedCoffee = true;
        UpdateRequest("coffeeWithSugar");
        StartCoroutine(TransitionToCoffeeWithSugar());
    }

    public void FeedCoffeeWithSugar()
    {
        SetStatus("Yum!");
        Debug.Log("Feed coffee with sugar. About to increase satisfaction.");

        if (satisfactionBar != null && !fedCoffeeWithSugar)
        {
            satisfactionBar.IncreaseSatisfaction(10f);
            currentSatisfaction = Mathf.Clamp(currentSatisfaction + 10f, 0, 100); // Update static satisfaction
        }

        if (!fedCoffeeWithSugar)
        {
            currentMoney += 5;
            UpdateMoneyText();
        }

        fedCoffeeWithSugar = true;
        UpdateRequest("coffeeWithCream");
        StartCoroutine(TransitionToCoffeeWithCream());
    }

    public void FeedCoffeeWithCream()
    {
        SetStatus("Perfect!");
        Debug.Log("Feed coffee with cream. About to increase satisfaction.");

        if (satisfactionBar != null && !fedCoffeeWithCream)
        {
            satisfactionBar.IncreaseSatisfaction(10f);
            currentSatisfaction = Mathf.Clamp(currentSatisfaction + 10f, 0, 100); // Update static satisfaction
        }

        if (!fedCoffeeWithCream)
        {
            currentMoney += 5;
            UpdateMoneyText();
        }

        fedCoffeeWithCream = true;
        StartCoroutine(TransitionToMatcha());
    }

    public void FeedMatchaMilk()
    {
        SetStatus("Yay!");
        Debug.Log("Feed Matcha Milk. About to increase satisfaction.");

        if (satisfactionBar != null && !fedMatchaMilk)
        {
            satisfactionBar.IncreaseSatisfaction(10f);
            currentSatisfaction = Mathf.Clamp(currentSatisfaction + 10f, 0, 100); // Update static satisfaction
        }

        if (!fedMatchaMilk)
        {
            currentMoney += 10;
            UpdateMoneyText();
        }

        fedMatchaMilk = true;
        StartCoroutine(TransitionToMoreSweet());
    }

    public void FeedMatchaMilkHoney()
    {
        SetStatus("Yay!");
        Debug.Log("Feed Matcha Milk Honey. About to increase satisfaction.");

        if (satisfactionBar != null && !fedMatchaMilkHoney)
        {
            satisfactionBar.IncreaseSatisfaction(15f);
            currentSatisfaction = Mathf.Clamp(currentSatisfaction + 10f, 0, 100); // Update static satisfaction
        }

        if (!fedMatchaMilkHoney)
        {
            currentMoney += 15;
            UpdateMoneyText();
        }

        fedMatchaMilkHoney = true;

        if (wonButton != null)
        {
            wonButton.gameObject.SetActive(true); // Activate the Won button
        }
        else
        {
            Debug.LogWarning("Won button is not assigned in the PlayerStatusManager.");
        }
    }

    private IEnumerator TransitionToCoffeeWithSugar()
    {
        yield return new WaitForSeconds(2f);
        SetStatus("Hmm... it could use a bit more sweetness");
        UpdateRequest("coffeeWithSugar");
    }

    private IEnumerator TransitionToCoffeeWithCream()
    {
        yield return new WaitForSeconds(2f);
        SetStatus("A little extra richness would make this perfect");
    }

    private IEnumerator TransitionToMatcha()
    {
        yield return new WaitForSeconds(2f);
        SetStatus("I’m craving a drink as serene as a forest, but with a cloud of white");
        UpdateRequest("matcha");
    }

    private IEnumerator TransitionToMoreSweet()
    {
        yield return new WaitForSeconds(2f);
        SetStatus("A mix of earth, cream, and the golden kiss of the sun—yes, that’s it");
        UpdateRequest("matcha");
    }

    // Method to update the money text UI element
    private void UpdateMoneyText()
    {
        if (moneyText != null)
        {
            moneyText.text = "$" + currentMoney.ToString();
        }
        else
        {
            Debug.LogWarning("Money Text is not assigned in the PlayerStatusManager.");
        }
    }

    // Method to update the status message depending on currentRequest
    private void UpdateStatusMessage()
    {
        switch (currentRequest)
        {
            case "coffee":
                SetStatus("I am feeling sluggish... maybe something brewed can help");
                break;
            case "coffeeWithSugar":
                SetStatus("Hmm... it could use a bit more sweetness");
                break;
            case "coffeeWithCream":
                SetStatus("A little extra richness would make this perfect");
                break;
            case "matcha":
                SetStatus("I’m craving a drink as serene as a forest, but with a cloud of white");
                break;
            case "matchaWithHoney":
                SetStatus("A mix of earth, cream, and the golden kiss of the sun—yes, that’s it");
                break;
            default:
                SetStatus("What do I want now?");
                break;
        }
    }

    // Coroutine to destroy the Won button after a delay
    private IEnumerator DestroyWonButtonAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (wonButton != null)
        {
            Destroy(wonButton.gameObject); // Destroy the Won button after the delay
            Debug.Log("Won button destroyed after " + delay + " seconds.");
        }
    }
}
