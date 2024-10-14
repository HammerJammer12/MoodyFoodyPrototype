using UnityEngine;
using UnityEngine.UI;

public class RecipeController : MonoBehaviour
{
    public Button recipeButton;   
    public Button closeButton;    
    public GameObject recipeImage; 

    void Start()
    {
        // Add listeners to the buttons
        recipeButton.onClick.AddListener(OpenRecipe);
        closeButton.onClick.AddListener(CloseRecipe);

        // Ensure the recipe image is initially hidden
        recipeImage.SetActive(false);
    }


    void OpenRecipe()
    {
        recipeImage.SetActive(true);
    }

    // Method to hide the recipe image
    void CloseRecipe()
    {
        recipeImage.SetActive(false);
    }
}
