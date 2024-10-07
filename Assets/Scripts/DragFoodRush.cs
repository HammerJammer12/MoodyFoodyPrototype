using UnityEngine;

public class DragFoodRush : MonoBehaviour
{
    private PersonRush personRushScript;
    private GameManagerRush gameManagerRush;
    private GameObject person;
    private Vector3 offset;
    private bool isDragging = false;

    void Start()
    {
        person = GameObject.Find("person");

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

        gameManagerRush = FindObjectOfType<GameManagerRush>();

        Debug.Log($"{gameObject.name} DragFoodRush script initialized.");
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
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

            if (gameObject.name.Contains("Apple") || gameObject.name.Contains("Cake"))
            {
                string foodType = gameObject.name.Contains("Apple") ? "Apple" : "Cake";
                personRushScript.AddFood(foodType);
                Debug.Log($"{foodType} added to person's food list.");

                Destroy(gameObject);
                Debug.Log($"{gameObject.name} destroyed after collision with the person.");

                CheckForTargetEmotion();
            }
            else
            {
                Debug.Log($"{gameObject.name} is not recognized as food, so no action is taken.");
            }
        }
        else
        {
            Debug.Log($"{gameObject.name} did not collide with the person.");
        }
    }

    void CheckForTargetEmotion()
    {
        Debug.Log("Checking if target emotion is reached...");
        if (personRushScript.GetTargetEmotion() == "Satisfaction" && personRushScript.HasReachedSatisfaction())
        {
            Debug.Log("Target emotion 'Satisfaction' reached!");
            personRushScript.SetEmotion("Satisfaction");
            gameManagerRush.ResetRound();
        }
        else
        {
            Debug.Log("Current foods fed do not match target emotion conditions yet.");
        }
    }
}
