using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private bool isDragging = false;
    public PlayerStatusManager playerStatusManager; // Reference to the PlayerStatusManager script

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        Debug.Log($"Started dragging: {gameObject.name} with tag {gameObject.tag}");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
        Debug.Log($"Stopped dragging: {gameObject.name} with tag {gameObject.tag}");
        CheckDropPosition();
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

    private void CheckDropPosition()
    {
        Vector2 pos = rectTransform.anchoredPosition;
        Debug.Log($"{gameObject.name} (Tag: {gameObject.tag}) Position: {pos}");

        if (pos.y >= -100 && pos.y <= 10 && pos.x >= -350 && pos.x <= -150)
        {
            Debug.Log($"{gameObject.name} is within the desired range.");

            if (gameObject.CompareTag("Coffee"))
            {
                playerStatusManager.FeedCoffee();
                
            }
            else if (gameObject.CompareTag("CoffeeWithSugar"))
            {
                playerStatusManager.FeedCoffeeWithSugar();
            }
            else if (gameObject.CompareTag("CoffeeWithCream"))
            {
                playerStatusManager.FeedCoffeeWithCream();
            }
            else if (gameObject.CompareTag("MatchaMilk"))
            {
                Debug.Log("MatchaMilk detected. Feeding the player MatchaMilk.");
                Destroy(gameObject);
                playerStatusManager.FeedMatchaMilk();
            }
            else if (gameObject.CompareTag("MatchaMilkHoney"))
            {
                Debug.Log("MatchaMilkHoney detected. Feeding the player MatchaMilkHoney.");
                Destroy(gameObject);
                playerStatusManager.FeedMatchaMilkHoney();
            }
            Destroy(gameObject);
        }
        else
        {
            Debug.Log($"{gameObject.name} is NOT within the desired range.");
        }
    }
}
