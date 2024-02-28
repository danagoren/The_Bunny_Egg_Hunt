using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] static GameManager Instance;
    [SerializeField] GameObject Bunny;
    [SerializeField] TextMeshProUGUI XPText;
    [SerializeField] TextMeshProUGUI Level;
    [SerializeField] TextMeshProUGUI TimerNum;
    [SerializeField] TextMeshProUGUI TimerNumRed;
    [SerializeField] TextMeshProUGUI GoldenEggs;
    [SerializeField] static int easterEggs = 0;
    [SerializeField] TextMeshProUGUI EasterEggs;
    [SerializeField] static int easterEggsNeeded;
    [SerializeField] TextMeshProUGUI EasterEggsNeeded;
    [SerializeField] GameObject youWin;
    [SerializeField] GameObject youLose;
    static float timer; //in seconds
    static int timerMinutes;
    static int timerSeconds;
    static string extraZero = "";
    static string timerStr = "";
    bool timerOn = false;

    // Start is called before the first frame update
    void Start()
    {
        timerOn = true;
        TimerNumRed.enabled = false;
        timer = 185;
        XPText.text = PlayerPrefs.GetInt("XP").ToString();
        Level.text = PlayerPrefs.GetInt("Level").ToString();
        GoldenEggs.text = PlayerPrefs.GetInt("GoldenEggs").ToString();
        easterEggs = 0;
        EasterEggs.text = easterEggs.ToString() + "/";
        easterEggsNeeded = 5;
        SetEasterEggs();
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
        GoldenEggs.text = PlayerPrefs.GetInt("GoldenEggs").ToString(); 
        EasterEggs.text = easterEggs.ToString() + "/";
        EasterEggsNeeded.text = easterEggsNeeded.ToString();
        XPText.text = PlayerPrefs.GetInt("XP").ToString();
        Level.text = PlayerPrefs.GetInt("Level").ToString();
    }

    static public void AddGoldenEgg()
    {
        PlayerPrefs.SetInt("GoldenEggs", PlayerPrefs.GetInt("GoldenEggs") + 1);
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
            PlayerPrefs.SetInt("XP", PlayerPrefs.GetInt("XP") + 2);
        }
        if (action.Equals("Easter Egg"))
        {
            PlayerPrefs.SetInt("XP", PlayerPrefs.GetInt("XP") + 5);
        }
        PlayerPrefs.SetInt("Level", 1 +(int)(PlayerPrefs.GetInt("XP") / 10));
    }

    private void UpdateTimer()
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

    private bool CheckIfWon()
    {
        if (easterEggsNeeded == easterEggs)
        {
            timerOn = false;
            return true;
        }
        return false;
    }

    private void PlayerWon()
    {
        //print winning message
        youWin.SetActive(true);
    }

    private bool CheckIfLost()
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

    private void PlayerLost()
    {
        //print lost message
        youLose.SetActive(true);

    }

    private void SetEasterEggs()
    {
        if (PlayerPrefs.GetInt("GameLevel") == 1)
        {
            easterEggsNeeded = 5;
        }
        if (PlayerPrefs.GetInt("GameLevel") == 2)
        {
            easterEggsNeeded = 6;
        }
        if (PlayerPrefs.GetInt("GameLevel") == 3)
        {
            easterEggsNeeded = 8;
        }
    }
}

