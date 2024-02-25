using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadingScene : MonoBehaviour
{
    public float delay = 5f;

    void Start()
    {
        // Start the coroutine to disable the object after 'delay' seconds
        StartCoroutine(DisableObjectAfterDelay());
    }

    IEnumerator DisableObjectAfterDelay()
    {
        yield return new WaitForSeconds(delay);

        // Disable the object
        gameObject.SetActive(false);
    }
}
