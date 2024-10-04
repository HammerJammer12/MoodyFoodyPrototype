using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewFoodItem", menuName = "Food/FoodItem")]
public class FoodSO : ScriptableObject
{
    public string Name;
    public Moods mood;
    public GameObject foodModel;
}

