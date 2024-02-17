using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private Rigidbody2D RB;
    [SerializeField] AudioSource audioCollect;
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
            audioCollect.Play();
            gameObject.SetActive(false);
        }
        if (gameObject.CompareTag("EasterEgg"))
        {
            GameManager.AddEasterEgg();
            audioCollect.Play();
            gameObject.SetActive(false);
        }
    }
}
