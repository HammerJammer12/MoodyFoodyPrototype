using UnityEngine;
using TMPro;  
using UnityEngine.UI;
using System.Collections.Generic;

public class ConfirmButtonScript : MonoBehaviour
{
    // List to store selected food items
    private List<string> selectedItems = new List<string>();

    // Maximum number of items that can be selected
    private const int maxSelection = 6;

    // Reference to the Confirm button
    public Button confirmButton;

    // References to the food item buttons
    public Button matchaButton; // Matcha
    public Button milkButton; // Milk
    public Button honeyButton; // Honey
    public Button croissantButton; // Croissant
    public Button yogurtButton; // Yogurt
    public Button vanillaButton; // Vanilla

    // References to the corresponding food GameObjects in the hierarchy
    public GameObject matchaObject;
    public GameObject milkObject;
    public GameObject honeyObject;
    public GameObject croissantObject;
    public GameObject yogurtObject;
    public GameObject vanillaObject;

    // Reference to the Menu GameObject (parent of all buttons or a UI panel)
    public GameObject menuObject;

    // Reference to the TextMeshProUGUI component that displays the money
    public TextMeshProUGUI moneyText;

    void Start()
    {
        // Add listeners to the food buttons
        matchaButton.onClick.AddListener(() => SelectFood(matchaButton));
        milkButton.onClick.AddListener(() => SelectFood(milkButton));
        honeyButton.onClick.AddListener(() => SelectFood(honeyButton));
        croissantButton.onClick.AddListener(() => SelectFood(croissantButton));
        yogurtButton.onClick.AddListener(() => SelectFood(yogurtButton));
        vanillaButton.onClick.AddListener(() => SelectFood(vanillaButton));

        // Add listener to the Confirm button
        confirmButton.onClick.AddListener(OnConfirmButtonClick);

        // Ensure all food GameObjects are initially disabled
        matchaObject.SetActive(false);
        milkObject.SetActive(false);
        honeyObject.SetActive(false);
        croissantObject.SetActive(false);
        yogurtObject.SetActive(false);
        vanillaObject.SetActive(false);
    }

    // Function to add food to the selected list
    private void SelectFood(Button foodButton)
    {
        string foodName = foodButton.name;  // Get the button's name

        if (selectedItems.Count < maxSelection)
        {
            if (!selectedItems.Contains(foodName))
            {
                selectedItems.Add(foodName);
            }
            // else
            // {
            //     Debug.Log($"{foodName} is already selected.");
            // }
        }
        // else
        // {
        //     Debug.Log("Maximum selection of 6 items reached.");
        // }
    }

    // Function to enable selected food objects and disable the menu when Confirm button is clicked
    private void OnConfirmButtonClick()
    {
        int foodCount = selectedItems.Count;  // Count how many food items have been selected

        if (foodCount > 0)
        {
            foreach (string item in selectedItems)
            {
                if (item == "Matcha") matchaObject.SetActive(true);
                else if (item == "Milk") milkObject.SetActive(true);
                else if (item == "Honey") honeyObject.SetActive(true);
                else if (item == "Croissant") croissantObject.SetActive(true);
                else if (item == "Yogurt") yogurtObject.SetActive(true);
                else if (item == "Vanilla") vanillaObject.SetActive(true);
            }

            // Deduct 2 money for each selected food item
            PlayerStatusManager.currentMoney = Mathf.Max(PlayerStatusManager.currentMoney - (foodCount * 2), 0);

            // Update the money display
            UpdateMoneyText();
        }

        // Disable the menu after confirming the selection
        if (menuObject != null)
        {
            menuObject.SetActive(false);
        }

        selectedItems.Clear();  // Optionally clear the selected items list after confirming
    }

    // Function to update the money display text
    private void UpdateMoneyText()
    {
        if (moneyText != null)
        {
            // Update the TextMeshProUGUI with the current money value
            moneyText.text = "$" + PlayerStatusManager.currentMoney.ToString();
        }
        else
        {
            Debug.LogError("Money TextMeshProUGUI is not assigned.");
        }
    }
}
