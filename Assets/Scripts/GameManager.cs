using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static int XP = 0;
    static int level = 0;
    static float timer; //in seconds
    static int timerMinutes;
    static int timerSeconds;
    static string extraZero = "";
    static string timerStr = "";
    bool timerOn = false;
    //public Text TimerText;
    public static int goldenEggs = 0;
    public static int easterEggs1 = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        timerOn = true;
        timer = 600;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
        PrintTester();
    }

    static public void AddGoldenEgg()
    {
        goldenEggs++;
        AddXP("Golden Egg");
    }

    static public void AddEasterEgg()
    {

        easterEggs1++;
        AddXP("Easter Egg");
    }
    static public void AddXP(string action)
    {
        if (action.Equals("Golden Egg"))
        {
            XP += 2;
        }
        if (action.Equals("Easter Egg"))
        {
            XP += 5;
        }
        level = (int)(XP / 10);
    }

    void UpdateTimer()
    {
        if (timerOn)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                timerOn = false;
                timer = 0;
            }
        }
        timerMinutes = (int)(timer / 60);
        timerSeconds = (int)(timer % 60);
        if (timerSeconds < 10)
        {
            extraZero = "0";
        }
        else
        {
            extraZero = "";
        }
        timerStr = (timerMinutes.ToString() + ":" + extraZero + timerSeconds.ToString());
    }

    static void PrintTester()
    {
        Debug.Log("Golden Eggs: " + goldenEggs + ", Easter Eggs: " + easterEggs1 + ", XP: " + XP + ", Level: " + level + ", timer: " + timerStr);
    }
}
