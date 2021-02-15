// Save data using the SaveSystem

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int totalApples;
    public int totalCarriers;
    public int totalBaskets;
    // public int totalShakers;

    public SaveData()
    {
        ScoreManager sManager = ScoreManager.Instance;
        totalApples = sManager.totalApples;
        totalCarriers = sManager.totalCarriers;
        totalBaskets = sManager.totalBaskets;
        // totalShakers = sManager.totalShakers;
    }

    public SaveData(bool wipe)
    {
        if (wipe) {
            ScoreManager sManager = ScoreManager.Instance;
            totalApples = 0;
            totalCarriers = 1;
            totalBaskets = 1;
            // totalShakers = 0;
        } else {
            ScoreManager sManager = ScoreManager.Instance;
            totalApples = sManager.totalApples;
            totalCarriers = sManager.totalCarriers;
            totalBaskets = sManager.totalBaskets;
            // totalShakers = sManager.totalShakers;
        }
    }
}
