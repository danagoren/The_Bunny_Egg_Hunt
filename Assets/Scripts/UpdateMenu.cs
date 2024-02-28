using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class UpdateMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Level;
    [SerializeField] TextMeshProUGUI XP;
    [SerializeField] TextMeshProUGUI GoldenEggs;
    [SerializeField] GameObject AstroLock;
    [SerializeField] GameObject RockerLock;
    [SerializeField] GameObject RainLock;
    [SerializeField] GameObject astroSkin;
    [SerializeField] GameObject bunnySkin;
    [SerializeField] GameObject rockerSkin;
    [SerializeField] GameObject rainSkin;
    static int flag = 0;


    // Start is called before the first frame update
    void Start()
    {
        if (flag == 0)
        {
            PlayerPrefs.SetInt("Level", 1);
            PlayerPrefs.SetInt("XP", 0);
            PlayerPrefs.SetInt("GoldenEggs", 0);
            PlayerPrefs.SetInt("Astro", 0);
            PlayerPrefs.SetInt("Rocker", 0);
            PlayerPrefs.SetInt("Rain", 0);
            flag++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Level.text = PlayerPrefs.GetInt("Level").ToString();
        XP.text = PlayerPrefs.GetInt("XP").ToString();
        GoldenEggs.text = PlayerPrefs.GetInt("GoldenEggs").ToString();
        OpenLocks();
        UpdateSkin();
    }

    //open locks for the outfits
    private void OpenLocks()
    {
        if (PlayerPrefs.GetInt("Level") >= 2)
        {
            AstroLock.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Level") >= 4)
        {
            RockerLock.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Level") >= 6)
        {
            RainLock.SetActive(false);
        }
    }

    private void UpdateSkin()
    {
        if (PlayerPrefs.GetInt("Astro") == 1)
        {
            astroSkin.SetActive(true);
            bunnySkin.SetActive(false);
            rockerSkin.SetActive(false);
            rainSkin.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Rocker") == 1)
        {
            astroSkin.SetActive(false);
            bunnySkin.SetActive(false);
            rockerSkin.SetActive(true);
            rainSkin.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Rain") == 1)
        {
            astroSkin.SetActive(false);
            bunnySkin.SetActive(false);
            rockerSkin.SetActive(false);
            rainSkin.SetActive(true);
        }
    }

    public void SetSkin(int val)
    {
        if (val == 0)
        {
            PlayerPrefs.SetInt("Astro", 0);
            PlayerPrefs.SetInt("Rocker", 0);
            PlayerPrefs.SetInt("Rain", 0);
        }
        if (val == 1)
        {
            PlayerPrefs.SetInt("Astro", 1);
            PlayerPrefs.SetInt("Rocker", 0);
            PlayerPrefs.SetInt("Rain", 0);
        }
        if (val == 2)
        {
            PlayerPrefs.SetInt("Astro", 0);
            PlayerPrefs.SetInt("Rocker", 1);
            PlayerPrefs.SetInt("Rain", 0);
        }
        if (val == 3)
        {
            PlayerPrefs.SetInt("Astro", 0);
            PlayerPrefs.SetInt("Rocker", 0);
            PlayerPrefs.SetInt("Rain", 1);
        }
    }

    public void SetGameLevel(int level)
    {
        if (level == 1)
        {
            PlayerPrefs.SetInt("GameLevel", 1);
        }
        if (level == 2)
        {
            PlayerPrefs.SetInt("GameLevel", 2);
        }
        if (level == 3)
        {
            PlayerPrefs.SetInt("GameLevel", 3);
        }

    }
}
