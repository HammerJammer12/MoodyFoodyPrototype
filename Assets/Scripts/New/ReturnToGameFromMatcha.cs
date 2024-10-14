using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToGameFromMatcha : MonoBehaviour
{
    // Static variables to track if the combinations are enabled
    public static bool matchaMilkEnabled = false;
    public static bool matchaMilkHoneyEnabled = false;

    // References to the combination objects in the current scene
    public GameObject matchaMilkObject;
    public GameObject matchaMilkHoneyObject;

    // Reference to the Return button (this can be linked in the inspector or automatically detected)
    public GameObject returnButton;

    void Start()
    {
        // Add listener to the Return button
        if (returnButton != null)
        {
            returnButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(OnReturnButtonClicked);
        }

        // Check if MatchaMilk or MatchaMilkHoney is enabled and set the static flags
        if (matchaMilkObject.activeSelf)
        {
            matchaMilkEnabled = true;
            Debug.Log("MatchaMilk is enabled.");
        }

        if (matchaMilkHoneyObject.activeSelf)
        {
            matchaMilkHoneyEnabled = true;
            Debug.Log("MatchaMilkHoney is enabled.");
        }
    }

    // This function is called when the Return button is clicked
    public void OnReturnButtonClicked()
    {
        Debug.Log("Returning to Game scene...");

        // Destroy MatchaMilk and MatchaMilkHoney objects if they are enabled
        if (matchaMilkEnabled && matchaMilkObject != null)
        {
            Destroy(matchaMilkObject);
            Debug.Log("MatchaMilk has been destroyed.");
        }

        if (matchaMilkHoneyEnabled && matchaMilkHoneyObject != null)
        {
            Destroy(matchaMilkHoneyObject);
            Debug.Log("MatchaMilkHoney has been destroyed.");
        }

        // Load the Game scene
        SceneManager.LoadScene("Game");
    }
}