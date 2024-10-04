using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //just for testing food stuff
    public FoodSO testFood;
    private GameObject test;

    void Start()
    {
        test = instantiateFood(testFood, new Vector3(0, 1, -8.5f));
    }

    public GameObject instantiateFood(FoodSO food, Vector3 pos)
    {
        if (food.foodModel != null)
        {
            GameObject foodInstance = Instantiate(food.foodModel, pos, Quaternion.identity);
            return foodInstance;
        }
        else return null;
    }
}
