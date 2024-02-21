using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    public GameObject objectToActivateDeactivate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bunny")) 
        {
            if (objectToActivateDeactivate != null)
            {
                objectToActivateDeactivate.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Bunny")) 
        {
            if (objectToActivateDeactivate != null)
            {
                objectToActivateDeactivate.SetActive(false);
            }
        }
    }
}