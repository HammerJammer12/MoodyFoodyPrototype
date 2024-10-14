using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    // Singleton instance
    public static GameSceneManager Instance { get; private set; }

    // Flag to indicate whether the CoffeeWithSugar button should be enabled
    public bool enableCoffeeWithSugarButton = false;

    private void Awake()
    {
        // Check if an instance already exists and is not this one
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Destroy the new instance if one already exists
            return;
        }

        // Set this instance as the Singleton instance
        Instance = this;

        // Make this GameObject persist across scenes
        DontDestroyOnLoad(gameObject);
    }

    // Method to set the enableCoffeeWithSugarButton flag
    public void SetEnableCoffeeWithSugarButton(bool value)
    {
        enableCoffeeWithSugarButton = value;
    }
}
