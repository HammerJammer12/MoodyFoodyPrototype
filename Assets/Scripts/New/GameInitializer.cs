using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    public GameObject coffeeWithSugarButton; // Reference to the CoffeeWithSugar button
    public GameObject coffeeWithCreamButton; // Reference to the CoffeeWithCream button
    public GameObject matchaMilkButton;      // Reference to the MatchaMilk button
    public GameObject matchaMilkHoneyButton; // Reference to the MatchaMilkHoney button

    void Start()
    {
        // Check if the static flag in DragAndCookCoffee is set to true
        if (DragAndCookCoffee.enableCoffeeWithSugar)
        {
            // Enable the CoffeeWithSugar button if the flag is true
            if (coffeeWithSugarButton != null)
            {
                coffeeWithSugarButton.SetActive(true);
            }

            // Reset the flag so it doesn't remain true for future scene loads
            DragAndCookCoffee.enableCoffeeWithSugar = false;
        }

        // Check if the static flag in DragAndCookCoffeeWithCream is set to true
        if (DragAndCookCoffeeWithCream.enableCoffeeWithCream)
        {
            // Enable the CoffeeWithCream button if the flag is true
            if (coffeeWithCreamButton != null)
            {
                coffeeWithCreamButton.SetActive(true);
            }

            // Reset the flag so it doesn't remain true for future scene loads
            DragAndCookCoffeeWithCream.enableCoffeeWithCream = false;
        }

        // Check if MatchaMilk was enabled in the previous scene
        if (CookMatcha.enableMatchaMilk)
        {
            if (matchaMilkButton != null)
            {
                matchaMilkButton.SetActive(true);
            }

            // Reset the flag so it doesn't remain true for future scene loads
            CookMatcha.enableMatchaMilk = false;
        }

        // Check if MatchaMilkHoney was enabled in the previous scene
        if (CookMatcha.enableMatchaMilkHoney)
        {
            if (matchaMilkHoneyButton != null)
            {
                matchaMilkHoneyButton.SetActive(true);
            }

            // Reset the flag so it doesn't remain true for future scene loads
            CookMatcha.enableMatchaMilkHoney = false;
        }
    }
}
