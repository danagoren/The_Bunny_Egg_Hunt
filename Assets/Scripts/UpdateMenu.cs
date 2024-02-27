using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class UpdateMenu : MonoBehaviour
{
    public TextMeshProUGUI Level;
    public TextMeshProUGUI XP;
    public TextMeshProUGUI GoldenEggs;
    public GameObject AstroLock;
    public GameObject RockerLock;
    public GameObject Lock3;
    public GameObject astroSkin;
    public GameObject bunnySkin;
    public GameObject rockerSkin;
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
    void OpenLocks()
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
            Lock3.SetActive(false);
        }
    }

    public void UpdateSkin()
    {
        if (PlayerPrefs.GetInt("Astro") == 1)
        {
            astroSkin.SetActive(true);
            bunnySkin.SetActive(false);
            rockerSkin.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Rocker") == 1)
        {
            astroSkin.SetActive(false);
            bunnySkin.SetActive(false);
            rockerSkin.SetActive(true);
        }
        Debug.Log("astro state: " + PlayerPrefs.GetInt("Astro"));
    }

    public void SetSkin(int val)
    {
        if (val == 0)
        {
            PlayerPrefs.SetInt("Astro", 0);
            PlayerPrefs.SetInt("Rocker", 0);
        }
        if (val == 1)
        {
            PlayerPrefs.SetInt("Astro", 1);
            PlayerPrefs.SetInt("Rocker", 0);
        }
        if (val == 2)
        {
            PlayerPrefs.SetInt("Rocker", 1);
            PlayerPrefs.SetInt("Astro", 0);
        }
    }
}
