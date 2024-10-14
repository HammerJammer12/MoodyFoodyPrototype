using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DragAndCookCoffee : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private bool isDragging = false;

    public GameObject coffeeButton;         // Reference to the Coffee button
    public GameObject sugarButton;          // Reference to the Sugar button
    public GameObject cookButton;           // Reference to the Cook button
    public GameObject coffeeSugarButton;    // Reference to the CoffeeSugar button (already in the hierarchy)
    public GameObject returnButton;         // Reference to the Return button

    // Static variable to track whether the CoffeeWithSugar button should be enabled
    public static bool enableCoffeeWithSugar = false;

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
                cookBtnComponent.onClick.AddListener(CookCoffeeSugar);
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

        // Make sure the CoffeeSugar button is initially disabled, if it exists
        if (coffeeSugarButton != null)
        {
            coffeeSugarButton.SetActive(false);
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

    // This function destroys Coffee and Sugar buttons and enables the CoffeeSugar button
    private void CookCoffeeSugar()
    {
        if (coffeeButton != null)
        {
            Destroy(coffeeButton);
        }

        if (sugarButton != null)
        {
            Destroy(sugarButton);
        }

        if (coffeeSugarButton != null)
        {
            coffeeSugarButton.SetActive(true);
        }

        // Set the static variable to true when cooking is complete
        enableCoffeeWithSugar = true;
    }

    public void ReturnToGameScene()
    {
        Debug.Log("ReturnToGameScene method called."); // Log when the method is called

        // Load the "Game" scene
        SceneManager.LoadScene("Game");
    }
}
