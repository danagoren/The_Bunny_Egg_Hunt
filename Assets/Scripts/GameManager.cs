using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int goldenEggs = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public void AddGoldenEgg()
    {
        goldenEggs++;
        Debug.Log("Golden Eggs: " + goldenEggs);
    }

    static public void AddEasterEgg(int type)
    {
        if (type == 1) { } //type represents the easter egg's type.
    }
}
