using UnityEngine;

public class DragFood : MonoBehaviour
{
    public GameObject person;  // Reference to the person object
    private Person personScript;
    private Vector3 offset;
    private bool isDragging = false;

    void Start()
    {
        // Get the Person script from the person GameObject
        personScript = person.GetComponent<Person>();
        if (personScript == null)
        {
            Debug.LogError("Person script not found on the object!");
        }
    }

    void Update()
    {
        // Handle dragging
        if (isDragging)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z; // Set z position based on object depth
            transform.position = Camera.main.ScreenToWorldPoint(mousePosition) + offset;
        }
    }

    void OnMouseDown()
    {
        // Start dragging
        isDragging = true;

        // Calculate offset to maintain the relative position of the object and the mouse
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z));
    }

    void OnMouseUp()
    {
        // Stop dragging
        isDragging = false;
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object collided with the person
        if (other.gameObject == person)
        {
            // Check what object is being dragged
            if (gameObject.name == "Apple")
            {
                personScript.SetHappy();  // Make person happy if it's an apple
                Destroy(gameObject);  // Destroy the apple immediately
                GameManager.instance.AddMoney(10);
            }
            else if (gameObject.name == "Cake")
            {
                personScript.SetAngry();  // Make person angry if it's a cake
                Destroy(gameObject);  // Destroy the cake immediately
                GameManager.instance.AddMoney(-5); //penalize player for making person angry? if not just remove this line
            }
        }
    }
}
