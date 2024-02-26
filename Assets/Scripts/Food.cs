using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class Food : MonoBehaviour
{
    public int goldenEggsCost = 10;
    public Button foodButton;

    // Start is called before the first frame update
    void Start()
    {
        foodButton.onClick.AddListener(PurchaseFood);
    }

    void PurchaseFood()
    {
        // Check if the player has enough golden eggs to afford the food item
        if (CanAfford())
        {
            PlayerPrefs.SetInt("GoldenEggs", PlayerPrefs.GetInt("GoldenEggs") - goldenEggsCost);

            PlayerPrefs.SetInt("XP", PlayerPrefs.GetInt("XP") + XPValue());

            GameManager.AddXP("Zero");

            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Not enough golden eggs to purchase this food!");
        }
    }

    int XPValue()
    {
        if (gameObject.name == "food")
        {
            return 1;
        }
       
        return 0;
    }

    // Check if the player has enough golden eggs
    bool CanAfford()
    {
        return PlayerPrefs.GetInt("GoldenEggs") >= goldenEggsCost;
    }
}