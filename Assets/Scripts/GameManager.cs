using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static int XP = 0;
    public TextMeshProUGUI XPText;
    static int level = 1;
    public TextMeshProUGUI Level;
    static float timer; //in seconds
    static int timerMinutes;
    static int timerSeconds;
    static string extraZero = "";
    static string timerStr = "";
    bool timerOn = false;
    public TextMeshProUGUI TimerNum;
    public TextMeshProUGUI TimerNumRed;
    public static int goldenEggs = 0;
    public TextMeshProUGUI GoldenEggs;
    public static int easterEggs = 0;
    public TextMeshProUGUI EasterEggs;
    static public int easterEggsNeeded;
    public TextMeshProUGUI EasterEggsNeeded;
    public GameObject youWin;
    public GameObject youLose;

    // Start is called before the first frame update
    void Start()
    {
        timerOn = true;
        TimerNumRed.enabled = false;
        timer = 70;
        XP = 0;
        XPText.text = XP.ToString();
        level = 1;
        Level.text = level.ToString();
        goldenEggs = 0;
        GoldenEggs.text = goldenEggs.ToString();
        easterEggs = 0;
        EasterEggs.text = easterEggs.ToString() + "/";
        easterEggsNeeded = 5;
        EasterEggsNeeded.text = easterEggsNeeded.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
        if (CheckIfWon())
        {
            PlayerWon();
        }
        if (CheckIfLost())
        {
            PlayerLost();
        }
        //PrintTester();
        GoldenEggs.text = goldenEggs.ToString();
        EasterEggs.text = easterEggs.ToString() + "/";
        EasterEggsNeeded.text = easterEggsNeeded.ToString();
        XPText.text = XP.ToString();
        Level.text = level.ToString();

    }

    static public void AddGoldenEgg()
    {
        goldenEggs++;
        AddXP("Golden Egg");
    }

    static public void AddEasterEgg()
    {

        easterEggs++;
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
        level = 1+(int)(XP / 10);
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
                //timerOn = false;
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
        TimerNum.text = timerStr;
        TimerNumRed.text = timerStr;
        if (timer < 60)
        {
            TimerNumRed.enabled = true;
            TimerNum.enabled = false;
        }
    }

    bool CheckIfWon()
    {
        if (easterEggsNeeded == easterEggs)
        {
            timerOn = false;
            return true;
        }
        return false;
    }

    void PlayerWon()
    {
        //print winning message
        youWin.SetActive(true);
    }

    bool CheckIfLost()
    {
        if (timerOn)
        {
            if (timer <= 0)
            {
                return true;
            }
        }
        return false;
    }

    void PlayerLost()
    {
        //print lost message
        youLose.SetActive(true);

    }

    static void PrintTester()
    {
        Debug.Log("Golden Eggs: " + goldenEggs + ", Easter Eggs: " + easterEggs + ", XP: " + XP + ", Level: " + level + ", timer: " + timerStr);
    }
}
