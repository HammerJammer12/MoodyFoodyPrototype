using UnityEngine;
using UnityEngine.UI;

public class BackgroundSwitcher : MonoBehaviour
{
    // References to the background images
    public GameObject defaultImage;        // Reference to the default image
    public GameObject background1Image;    // Reference for Classic background
    public GameObject background2Image;    // Reference for Space background
    public GameObject background3Image;    // Reference for Background 3

    // References to the buttons
    public Button defaultButton;           // Button to select Default background
    public Button classicButton;           // Button to select Classic background
    public Button spaceButton;             // Button to select Space background
    public Button background3Button;       // Button to select Background 3
    public Button confirmButton;           // Button to confirm the selection

    // Static variable to store the last enabled background (accessible across scenes)
    public static string lastEnabledBackground = "default";  // Default background by default

    void Start()
    {
        // Add listeners to the buttons
        defaultButton.onClick.AddListener(SetDefaultBackground);
        classicButton.onClick.AddListener(SetClassicBackground);
        spaceButton.onClick.AddListener(SetSpaceBackground);
        background3Button.onClick.AddListener(SetBackground3);
        confirmButton.onClick.AddListener(ConfirmSelection);

        // Optionally, you can load the last confirmed background at the start
        LoadLastConfirmedBackground();
    }

    // Function to enable the Default background and disable all others
    public void SetDefaultBackground()
    {
        DisableAllBackgrounds(); // Disable all images first
        defaultImage.SetActive(true); // Enable the Default background
        lastEnabledBackground = "default";  // Set the last enabled background to default
    }

    // Function to enable the Classic background and disable all others
    public void SetClassicBackground()
    {
        DisableAllBackgrounds(); // Disable all images first
        background1Image.SetActive(true); // Enable the Classic background
        lastEnabledBackground = "classic";  // Set the last enabled background to classic
    }

    // Function to enable the Space background and disable all others
    public void SetSpaceBackground()
    {
        DisableAllBackgrounds(); // Disable all images first
        background2Image.SetActive(true); // Enable the Space background
        lastEnabledBackground = "space";  // Set the last enabled background to space
    }

    // Function to enable the Background3 image and disable all others
    public void SetBackground3()
    {
        DisableAllBackgrounds(); // Disable all images first
        background3Image.SetActive(true); // Enable the Background 3 image
        lastEnabledBackground = "background3";  // Set the last enabled background to background 3
    }

    // Function to confirm the selected background
    public void ConfirmSelection()
    {
        // If the confirmed background is not the default, deduct 30 money
        if (lastEnabledBackground != "default")
        {
            DeductMoney(30); // Deduct 30 money when selecting a background other than default
        }

        Debug.Log("Confirmed background: " + lastEnabledBackground);
    }

    // Function to disable all backgrounds
    private void DisableAllBackgrounds()
    {
        defaultImage.SetActive(false);       // Disable the default image
        background1Image.SetActive(false);   // Disable the Classic background
        background2Image.SetActive(false);   // Disable the Space background
        background3Image.SetActive(false);   // Disable Background 3
    }

    // Function to load the last confirmed background at the start of the scene
    private void LoadLastConfirmedBackground()
    {
        DisableAllBackgrounds(); // Disable all backgrounds first

        // Load the last confirmed background based on the static variable
        switch (lastEnabledBackground)
        {
            case "default":
                defaultImage.SetActive(true);
                break;
            case "classic":
                background1Image.SetActive(true);
                break;
            case "space":
                background2Image.SetActive(true);
                break;
            case "background3":
                background3Image.SetActive(true);
                break;
            default:
                defaultImage.SetActive(true); // Fallback to default
                break;
        }
    }

    // Method to deduct money from PlayerStatusManager
    private void DeductMoney(int amount)
    {
        PlayerStatusManager.currentMoney -= amount; // Deduct money
        PlayerStatusManager.currentMoney = Mathf.Max(PlayerStatusManager.currentMoney, 0); // Ensure money does not go below zero

        // Update the money display if necessary (optional)
        MoneyTracker moneyTracker = FindObjectOfType<MoneyTracker>();
        if (moneyTracker != null)
        {
            moneyTracker.RefreshMoneyDisplay();  // Update the money display
        }

        Debug.Log("Money deducted: " + amount + ". Current money: " + PlayerStatusManager.currentMoney);
    }
}
