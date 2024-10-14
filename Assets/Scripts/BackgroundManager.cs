using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    // References to the background images in the Game scene
    public GameObject defaultImage;        
    public GameObject background1Image;    
    public GameObject background2Image;    
    public GameObject background3Image;    

    void Start()
    {
        // Load and apply the background based on the last selected one in the BackgroundSwitcher
        ApplyBackground();
    }

    // Function to apply the selected background
    void ApplyBackground()
    {
        // Disable all backgrounds first
        DisableAllBackgrounds();

        // Check which background was selected and activate the correct one
        switch (BackgroundSwitcher.lastEnabledBackground)
        {
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
                defaultImage.SetActive(true);  // Default fallback
                break;
        }
    }

    // Function to disable all background images
    void DisableAllBackgrounds()
    {
        defaultImage.SetActive(false);
        background1Image.SetActive(false);
        background2Image.SetActive(false);
        background3Image.SetActive(false);
    }
}
