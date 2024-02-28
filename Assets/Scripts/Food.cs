using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class Food : MonoBehaviour
{
    public int goldenEggsCost = 10;
    public Button foodButton;
    public GameObject restock;

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
            restock.SetActive(true);
        }
        else
        {
            Debug.Log("Not enough golden eggs to purchase this food!");
        }
    }

    int XPValue()
    {
        if (gameObject.name == "food(1)")
        {
            return 1;
        }
        if (gameObject.name == "food(2)")
        {
            return 3;
        }
        if (gameObject.name == "food(4)")
        {
            return 7;
        }

        return 0;
    }

    // Check if the player has enough golden eggs
    bool CanAfford()
    {
        return PlayerPrefs.GetInt("GoldenEggs") >= goldenEggsCost;
    }
}