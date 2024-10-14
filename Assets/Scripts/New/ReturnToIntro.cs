using UnityEngine;
using UnityEngine.UI;   // Import for Button class
using UnityEngine.SceneManagement;  // Import for SceneManager

public class ReturnToIntro : MonoBehaviour
{
    public Button returnButton;  // Reference to the return button

    void Start()
    {
        // Add listener to the button to call ReturnToIntro when clicked
        returnButton.onClick.AddListener(ReturnToIntroScene);
    }

    // Method to return to the Intro scene
    public void ReturnToIntroScene()
    {
        SceneManager.LoadScene("Intro");  // Load the Intro scene
    }
}
