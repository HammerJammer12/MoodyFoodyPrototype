using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerNormal : MonoBehaviour
{
    public static GameManagerNormal instance;
    public TextMeshProUGUI moneyDisplayText;
    public int money;
    void Awake()
    {
        instance = this;
        money = 0;
        
    }

    void Update()
    {
        //update money text
        moneyDisplayText.text = "Money: " + money.ToString();
    }

    public void AddMoney(int amount)
    {
        money += amount;
        if (money < 0)
        {
            money = 0;
        }
    }
}
