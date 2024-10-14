using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToSceneCoffeeSugar : MonoBehaviour
{
    private Button cookButton;

    void Start()
    {
        cookButton = GetComponent<Button>();

        if (cookButton != null)
        {
            cookButton.onClick.AddListener(OnCookButtonClick);
        }
    }

    private void OnCookButtonClick()
    {
        Debug.Log("Current status: " + PlayerStatusManager.currentRequest); // Accessing static variable

        // Load the appropriate scene based on the player's current request
        if (PlayerStatusManager.currentRequest == "coffeeWithSugar")
        {
            SceneManager.LoadScene("CoffeeWithSugar");
            Debug.Log("Loading scene: CoffeeWithSugar");
        }
        else if (PlayerStatusManager.currentRequest == "coffeeWithCream")
        {
            SceneManager.LoadScene("CoffeeWithCream");
            Debug.Log("Loading scene: CoffeeWithCream");
        }
        else if (PlayerStatusManager.currentRequest == "matcha")
        {
            SceneManager.LoadScene("CoffeeMatcha");
            Debug.Log("Loading scene: CoffeeMatcha");
        }
        else
        {
            Debug.LogWarning("Unknown request. No scene loaded.");
        }
    }
}
