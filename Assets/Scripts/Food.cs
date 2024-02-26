using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Food : MonoBehaviour

{
    int value = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            PlayerPrefs.SetInt("XP", PlayerPrefs.GetInt("XP") + XPValue());
            GameManager.AddXP("Zero"); //to update the level

            gameObject.SetActive(false);
        }

    }

    int XPValue()
    {
        if (gameObject.name == "strawberrycheese")
        {
            return 1;
        }//...



        return 0;
    }

}
