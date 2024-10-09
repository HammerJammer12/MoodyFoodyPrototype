using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public Button normalButton;  // Reference to the Normal button
    public Button rushButton;    // Reference to the Rush button
    public Button returnButton; 

    void Start()
    {
        // Add listeners to the buttons (if they exist in the current scene)
        if (normalButton != null)
            normalButton.onClick.AddListener(OpenNormalScene);
        
        if (rushButton != null)
            rushButton.onClick.AddListener(OpenRushScene);
        
        if (returnButton != null)
            returnButton.onClick.AddListener(ReturnToIntro);
    }

    // Method to load the Normal game scene
    void OpenNormalScene()
    {
        SceneManager.LoadScene("Game"); 
    }

    // Method to load the Rush game scene
    void OpenRushScene()
    {
        SceneManager.LoadScene("Rush"); 
    }

    // Method to return to the Intro scene
    public void ReturnToIntro()
    {
        SceneManager.LoadScene("Intro"); 
    }
}
