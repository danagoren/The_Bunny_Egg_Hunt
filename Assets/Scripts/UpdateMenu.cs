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
    /*static int level = 1;
    static int XPNum = 0;
    public static int goldenEggs = 0;*/
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
    }
}
