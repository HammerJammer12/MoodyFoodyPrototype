using System.Collections.Generic;
using UnityEngine;

public class DragFoodRush : MonoBehaviour
{
    public GameObject foodPrefab;  // Reference to the food prefab
    private PersonRush personRushScript;
    private List<string> foodsFed = new List<string>();
    private GameManagerRush gameManagerRush;
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private GameObject person;  // Reference to the person object
    private Vector3 offset;
    private bool isDragging = false;

    void Start()
    {
        // Find the person object dynamically in the scene
        person = GameObject.Find("person"); // Make sure the name matches the GameObject in your hierarchy

        if (person != null)
        {
            personRushScript = person.GetComponent<PersonRush>();
            if (personRushScript == null)
            {
                Debug.LogError("PersonRush script not found on the person object!");
            }
        }
        else
        {
            Debug.LogError("Person GameObject not found in the scene!");
        }

        // Get the GameManagerRush instance
        gameManagerRush = FindObjectOfType<GameManagerRush>();

        // Store the original position and rotation of the food object
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        // Debug message for setup confirmation
        Debug.Log($"{gameObject.name} DragFoodRush script initialized.");
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z; // Use object's z position
            transform.position = Camera.main.ScreenToWorldPoint(mousePosition) + offset;
        }
    }

    void OnMouseDown()
    {
        isDragging = true;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        offset = transform.position - Camera.main.ScreenToWorldPoint(mousePosition);
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{gameObject.name} entered collision with {other.gameObject.name}");

        if (other.gameObject == person)
        {
            Debug.Log($"{gameObject.name} collided with the person!");

            if (gameObject.name == "Apple" || gameObject.name == "Cake")
            {
                foodsFed.Add(gameObject.name);
                Destroy(gameObject);
                CheckForTargetEmotion();
                Invoke(nameof(RespawnFood), 1f);
            }
        }
    }

    void CheckForTargetEmotion()
    {
        if (personRushScript.GetTargetEmotion() == "Satisfaction" && HasReachedSatisfaction())
        {
            personRushScript.SetEmotion("Satisfaction");
            Invoke(nameof(ResetRound), 1f);
        }
        else if (personRushScript.GetTargetEmotion() == "Disgust" && HasReachedDisgust())
        {
            personRushScript.SetEmotion("Disgust");
            Debug.Log("You won");
            Invoke(nameof(ResetRound), 1f);
        }
    }

    private bool HasReachedSatisfaction()
    {
        int appleCount = foodsFed.FindAll(f => f == "Apple").Count;
        int cakeCount = foodsFed.FindAll(f => f == "Cake").Count;
        return appleCount == 2 && cakeCount == 2;
    }

    private bool HasReachedDisgust()
    {
        int cakeCount = foodsFed.FindAll(f => f == "Cake").Count;
        return cakeCount == 5;
    }

    void ResetRound()
    {
        foodsFed.Clear();
        personRushScript.ResetEmotion();
        gameManagerRush.ResetRound();
    }

    void RespawnFood()
    {
        GameObject newFood = Instantiate(foodPrefab, originalPosition, originalRotation);
        newFood.name = foodPrefab.name;

        DragFoodRush dragFoodRushScript = newFood.GetComponent<DragFoodRush>();
        if (dragFoodRushScript != null)
        {
            dragFoodRushScript.foodPrefab = foodPrefab;
        }
        else
        {
            Debug.LogError("DragFoodRush script not found on the new food instance.");
        }
    }
}
