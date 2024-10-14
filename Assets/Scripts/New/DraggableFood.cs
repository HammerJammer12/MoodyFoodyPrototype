using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableFood : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private bool isDragging = false;

    // Track if the item has been dragged
    public static bool matchaDragged = false;
    public static bool milkDragged = false;
    public static bool honeyDragged = false;

    public GameObject matchaButton;    // Reference to the Matcha button
    public GameObject milkButton;      // Reference to the Milk button
    public GameObject honeyButton;     // Reference to the Honey button

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        PrintItemBeingDragged(gameObject.name);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
        Debug.Log($"{gameObject.name} drag ended.");
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

    // Function to print the name of the dragged item and set flags
    private void PrintItemBeingDragged(string itemName)
    {
        if (itemName == matchaButton.name)
        {
            matchaDragged = true;
            Debug.Log("Matcha is being dragged.");
        }
        else if (itemName == milkButton.name)
        {
            milkDragged = true;
            Debug.Log("Milk is being dragged.");
        }
        else if (itemName == honeyButton.name)
        {
            honeyDragged = true;
            Debug.Log("Honey is being dragged.");
        }
        else
        {
            Debug.Log("Unknown item is being dragged.");
        }
    }
}
