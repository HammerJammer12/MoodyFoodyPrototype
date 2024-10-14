using UnityEngine;
using UnityEngine.UI;

public class BuyFoodController : MonoBehaviour
{
    public Button buyFoodButton;     // Reference to the Buy Food button
    public Button closeButton;       // Reference to the Close button for Buy Food
    public GameObject buyFoodImage;  // Reference to the Buy Food Image

    void Start()
    {
        // Add listeners to the buttons
        buyFoodButton.onClick.AddListener(OpenBuyFood);
        closeButton.onClick.AddListener(CloseBuyFood);

        // Ensure the buy food image is initially hidden
        buyFoodImage.SetActive(false);
    }

    // Method to show the buy food image
    void OpenBuyFood()
    {
        buyFoodImage.SetActive(true);
    }

    // Method to hide the buy food image
    void CloseBuyFood()
    {
        buyFoodImage.SetActive(false);
    }
}
