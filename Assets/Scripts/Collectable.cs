using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private Rigidbody2D RB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Bunny")) { return; }

        if (gameObject.CompareTag("GoldenEgg"))
        {
            GameManager.AddGoldenEgg();
            gameObject.SetActive(false);
            //add 1 to golden egg count
            //disable this collectable
        }
        if (gameObject.CompareTag("EasterEgg"))
        {
            GameManager.AddEasterEgg(); //give the function a number that represents the easter egg's type
            gameObject.SetActive(false);
        }
    }
}
