using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLVL1 : MonoBehaviour
{

    public void Next()
    {
        SceneManager.LoadScene(1);
    }

}