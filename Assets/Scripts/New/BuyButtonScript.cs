using UnityEngine;
using UnityEngine.UI;

public class BuyButtonScript : MonoBehaviour
{
    public Button menuButton; // Reference to the "Menu" button

    void Start()
    {
        // Ensure the "Menu" button is initially disabled
        if (menuButton != null)
        {
            menuButton.gameObject.SetActive(false);
        }
    }

    public void OnBuyButtonClick()
    {
        // Enable the "Menu" button
        if (menuButton != null)
        {
            menuButton.gameObject.SetActive(true);
            Debug.Log("Menu button is now enabled.");
        }
    }
}
