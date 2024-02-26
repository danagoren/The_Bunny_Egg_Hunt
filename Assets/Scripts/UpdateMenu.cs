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
    public GameObject RockLock;
    public GameObject Lock3;
    static int flag = 0;


    // Start is called before the first frame update
    void Start()
    {
        if (flag == 0)
        {
            PlayerPrefs.SetInt("Level", 1);
            PlayerPrefs.SetInt("XP", 0);
            PlayerPrefs.SetInt("GoldenEggs", 0);
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
            RockLock.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Level") >= 6)
        {
            Lock3.SetActive(false);
        }
    }
}
