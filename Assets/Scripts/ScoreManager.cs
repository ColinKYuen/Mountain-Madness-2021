using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance
    {
        get;
        private set;
    }

    public int totalApples;
    public int totalCarriers;
    public int totalBaskets;
    public int totalShakers;

    public TextMeshProUGUI scoreGame;
    public TextMeshProUGUI scoreStore;

    void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        totalApples = 0;
        totalCarriers = 0;
        totalBaskets = 0;
        totalShakers = 0;
    }

    void Update()
    {
        scoreGame.text = totalApples.ToString();
        scoreStore.text = totalApples.ToString();
    }
}
