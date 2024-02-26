using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OutfitsUnlocker : MonoBehaviour
{
    public int levelsPerOutfit = 2; 
    public GameObject[] outfitImages; 
    public int[] unlockLevels; 

    private int currentLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = PlayerPrefs.GetInt("PlayerLevel", 0);

        for (int i = 0; i < outfitImages.Length; i++)
        {
            if (currentLevel < unlockLevels[i])
            {
                outfitImages[i].SetActive(true);
            }
        }
    }

    // Call this when the player levels up
    public void LevelUp()
    {
        
        currentLevel++;

        PlayerPrefs.SetInt("PlayerLevel", currentLevel);

        // Check if any outfits should be unlocked
        for (int i = 0; i < outfitImages.Length; i++)
        {
            if (currentLevel >= unlockLevels[i] && currentLevel % levelsPerOutfit == 0)
            {
                outfitImages[i].SetActive(false);
            }
        }
    }
}
