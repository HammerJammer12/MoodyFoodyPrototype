using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public Button normalButton;  // Reference to the Normal button
    public Button upgradeButton; // Reference to the Upgrade button

    void Start()
    {
        // Add listeners to the buttons
        if (normalButton != null)
            normalButton.onClick.AddListener(OpenNormalScene);
        
        if (upgradeButton != null)
            upgradeButton.onClick.AddListener(OpenUpgradeScene);
    }

    // Method to load the Normal game scene
    void OpenNormalScene()
    {
        SceneManager.LoadScene("Game");  // Load the Game scene
    }

    // Method to load the Upgrade scene
    void OpenUpgradeScene()
    {
        SceneManager.LoadScene("Upgrade"); 
    }
}
