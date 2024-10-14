using UnityEngine;

public class CookMatcha : MonoBehaviour
{
    // Static variables to track whether the combinations are enabled
    public static bool enableMatchaMilk = false;
    public static bool enableMatchaMilkHoney = false;

    // References to the combination objects
    public GameObject matchaMilkObject;       // Combination: Matcha + Milk
    public GameObject matchaMilkHoneyObject;  // Combination: Matcha + Milk + Honey

    // References to the individual food objects
    public GameObject matchaButton;
    public GameObject milkButton;
    public GameObject honeyButton;

    void Start()
    {
        // Make sure combination objects are disabled at the start
        matchaMilkObject.SetActive(false);
        matchaMilkHoneyObject.SetActive(false);
    }

    // This function is called when the Cook button is clicked
    public void OnCookButtonClicked()
    {
        // Check if matcha, milk, and honey are dragged
        if (DraggableFood.matchaDragged && DraggableFood.milkDragged && DraggableFood.honeyDragged)
        {
            EnableCombination(matchaMilkHoneyObject);
            enableMatchaMilkHoney = true;  // Set the flag for MatchaMilkHoney
            DestroyFoodItems();
        }
        // Check if only matcha and milk are dragged
        else if (DraggableFood.matchaDragged && DraggableFood.milkDragged)
        {
            EnableCombination(matchaMilkObject);
            enableMatchaMilk = true;  // Set the flag for MatchaMilk
            DestroyFoodItems();
        }
        else
        {
            Debug.Log("Not enough ingredients to cook.");
        }
    }

    // This function enables the combination object
    private void EnableCombination(GameObject combinationObject)
    {
        combinationObject.SetActive(true);
        Debug.Log($"{combinationObject.name} enabled.");
    }

    // Destroy the food items after combining
    private void DestroyFoodItems()
    {
        if (DraggableFood.matchaDragged)
        {
            Destroy(matchaButton);
            Debug.Log("Matcha destroyed.");
        }
        if (DraggableFood.milkDragged)
        {
            Destroy(milkButton);
            Debug.Log("Milk destroyed.");
        }
        if (DraggableFood.honeyDragged)
        {
            Destroy(honeyButton);
            Debug.Log("Honey destroyed.");
        }
    }
}
