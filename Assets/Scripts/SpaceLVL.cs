using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceLVL : MonoBehaviour
{

    public void Next()
    {
        SceneManager.LoadScene(4);
    }

}