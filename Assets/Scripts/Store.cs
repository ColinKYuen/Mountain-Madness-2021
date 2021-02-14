using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Store : MonoBehaviour
{
    public TextMeshProUGUI carrierText;
    public TextMeshProUGUI basketText;
    public TextMeshProUGUI shakerText;

    public int totalCarriers = 0;
    public int totalBaskets = 0;
    public int totalShakers = 0;
    public int score = 0;

    public void BuyCarriers()
    {
        int carrierCost = (int)Math.Pow(2.0, Math.Pow(2.0, (double)totalCarriers * 5));
        if(score >= carrierCost)
        {
            totalCarriers += 1;
            score -= carrierCost;
        }
        carrierText.text = carrierCost.ToString();
    }

    public void BuyBaskets()
    {
        int basketCost = (int)Math.Pow(2.0, Math.Pow(2.0, (double)totalBaskets * 2));
        if (score >= basketCost)
        {
            totalBaskets += 1;
            score -= basketCost;
        }
        basketText.text = basketCost.ToString();
    }

    public void BuyShakers()
    {
        int shakerCost = (int)Math.Pow(2.0, Math.Pow(2.0, (double)totalShakers * 5));
        if (score >= shakerCost)
        {
            totalShakers += 1;
            score -= shakerCost;
        }
        shakerText.text = shakerCost.ToString();
    }
}
