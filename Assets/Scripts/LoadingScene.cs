using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadingScene : MonoBehaviour
{
    public string loading;
    public string nextScene;

    void Start()
    {
        // Load the second scene
        SceneManager.LoadScene(loading, LoadSceneMode.Additive);

        // Wait for 5 seconds
        StartCoroutine(WaitAndLoadThirdScene());
    }

    IEnumerator WaitAndLoadThirdScene()
    {
        yield return new WaitForSeconds(5);

        // Unload the second scene
        SceneManager.UnloadSceneAsync(loading);

        // Load the third scene
        SceneManager.LoadScene(nextScene, LoadSceneMode.Additive);
    }
}