using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DragAndCookCoffeeWithCream : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private bool isDragging = false;

    public GameObject coffeeButton;         // Reference to the Coffee button
    public GameObject creamButton;          // Reference to the Cream button
    public GameObject cookButton;           // Reference to the Cook button
    public GameObject coffeeCreamButton;    // Reference to the CoffeeCream button (already in the hierarchy)
    public GameObject returnButton;         // Reference to the Return button

    // Static variable to track whether the CoffeeWithCream button should be enabled
    public static bool enableCoffeeWithCream = false;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();

        // Add the cook functionality to the cook button, if it exists
        if (cookButton != null)
        {
            Button cookBtnComponent = cookButton.GetComponent<Button>();
            if (cookBtnComponent != null)
            {
                cookBtnComponent.onClick.AddListener(CookCoffeeCream);
            }
        }

        // Add the return functionality to the return button, if it exists
        if (returnButton != null)
        {
            Button returnBtnComponent = returnButton.GetComponent<Button>();
            if (returnBtnComponent != null)
            {
                // Add a listener to call ReturnToGameScene when the button is clicked
                returnBtnComponent.onClick.AddListener(ReturnToGameScene);
            }
            else
            {
                Debug.LogWarning("Return button does not have a Button component attached.");
            }
        }
        else
        {
            Debug.LogWarning("Return button is not assigned.");
        }

        // Make sure the CoffeeCream button is initially disabled, if it exists
        if (coffeeCreamButton != null)
        {
            coffeeCreamButton.SetActive(false);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            Vector2 movePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform, 
                eventData.position, 
                canvas.worldCamera, 
                out movePos);
            rectTransform.anchoredPosition = movePos;
        }
    }

    // This function destroys Coffee and Cream buttons and enables the CoffeeCream button
    private void CookCoffeeCream()
    {
        if (coffeeButton != null)
        {
            Destroy(coffeeButton);
        }

        if (creamButton != null)
        {
            Destroy(creamButton);
        }

        if (coffeeCreamButton != null)
        {
            coffeeCreamButton.SetActive(true);
        }

        // Set the static variable to true when cooking is complete
        enableCoffeeWithCream = true;
    }

    public void ReturnToGameScene()
    {
        Debug.Log("ReturnToGameScene method called."); // Log when the method is called

        // Load the "Game" scene
        SceneManager.LoadScene("Game");
    }
}
