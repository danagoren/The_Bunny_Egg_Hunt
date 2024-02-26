using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject Bunny;
    //static int XP = 0;
    public TextMeshProUGUI XPText;
    //static int level = 1;
    public TextMeshProUGUI Level;
    static float timer; //in seconds
    static int timerMinutes;
    static int timerSeconds;
    static string extraZero = "";
    static string timerStr = "";
    bool timerOn = false;
    public TextMeshProUGUI TimerNum;
    public TextMeshProUGUI TimerNumRed;
    //public static int goldenEggs = 0;
    public TextMeshProUGUI GoldenEggs;
    public static int easterEggs = 0;
    public TextMeshProUGUI EasterEggs;
    static public int easterEggsNeeded;
    public TextMeshProUGUI EasterEggsNeeded;
    public GameObject youWin;
    public GameObject youLose;

    /*private void Awake()
    {
        Instance = this;
        //DontDestroyOnLoad(gameObject);

    }*/

    // Start is called before the first frame update
    void Start()
    {
        timerOn = true;
        TimerNumRed.enabled = false;
        timer = 70;
        //XP = 0;
        XPText.text = PlayerPrefs.GetInt("XP").ToString();
        //level = 1;
        Level.text = PlayerPrefs.GetInt("Level").ToString();
        //goldenEggs = 0;
        GoldenEggs.text = PlayerPrefs.GetInt("GoldenEggs").ToString();
        easterEggs = 0;
        EasterEggs.text = easterEggs.ToString() + "/";
        easterEggsNeeded = 5;
        EasterEggsNeeded.text = easterEggsNeeded.ToString();
        /*PlayerPrefs.SetInt("goldenEggs", goldenEggs);
        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.SetInt("XP", XP);*/
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
        GoldenEggs.text = PlayerPrefs.GetInt("GoldenEggs").ToString(); 
        EasterEggs.text = easterEggs.ToString() + "/";
        EasterEggsNeeded.text = easterEggsNeeded.ToString();
        XPText.text = PlayerPrefs.GetInt("XP").ToString();
        Level.text = PlayerPrefs.GetInt("Level").ToString();
        //PlayerPrefs.SetInt("easterEggs", easterEggs);
        //goldenEggs = PlayerPrefs.GetInt("goldenEggs");
        //level = PlayerPrefs.GetInt("Level");
        //XP = PlayerPrefs.GetInt("XP");

    }

    static public void AddGoldenEgg()
    {
        PlayerPrefs.SetInt("GoldenEggs", PlayerPrefs.GetInt("GoldenEggs") + 1);
        AddXP("Golden Egg");
    }

    static public void AddEasterEgg()
    {
        easterEggs++;
        //PlayerPrefs.SetInt("easterEggs", ++easterEggs);
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
        //PlayerPrefs.SetInt("XP", XP);
        //PlayerPrefs.SetInt("Level", level);
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
        //Debug.Log("Golden Eggs: " + goldenEggs + ", Easter Eggs: " + easterEggs + ", XP: " + XP + ", Level: " + level + ", timer: " + timerStr);
    }
}
