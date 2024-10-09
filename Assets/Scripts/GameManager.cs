using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 
    public TextMeshProUGUI moneyText;   
    private int money = 0;           

    void Awake()
    {
        // Singleton pattern to ensure only one instance of GameManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Optional: keeps GameManager alive across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Initialize the money text display
        UpdateMoneyText();
    }

    // Method to increment money
    public void AddMoney(int amount)
    {
        money += amount;
        UpdateMoneyText();
    }

    // Method to update the money text display
    private void UpdateMoneyText()
    {
        if (moneyText != null)
        {
            moneyText.text = money.ToString(); // Display the numeric value
        }
    }
}
