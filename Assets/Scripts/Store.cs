using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Store : MonoBehaviour
{
    public TextMeshProUGUI carrierText;
    public TextMeshProUGUI basketText;
    public TextMeshProUGUI shakerText;

    private ScoreManager sManager;
    private int carrierCost;
    private int basketCost;
    private int shakerCost;

    void Start()
    {
        sManager = ScoreManager.Instance;
        carrierCost = 1 + (int)Math.Pow(2.0, (double)sManager.totalCarriers * 1.690);
        basketCost = 1 + (int)Math.Pow(2.0, (double)sManager.totalBaskets * 1.420);
        shakerCost = 1 + (int)Math.Pow(2.0, (double)sManager.totalShakers * 1.69420);
        carrierText.text = carrierCost.ToString();
        basketText.text = basketCost.ToString();
        shakerText.text = shakerCost.ToString();
    }

    public void BuyCarriers()
    {
        if(sManager.totalApples >= carrierCost)
        {
            sManager.totalCarriers += 1;
            sManager.totalApples -= carrierCost;
            carrierCost = 1 + (int)Math.Pow(2.0, (double)sManager.totalCarriers * 1.690);
            carrierText.text = carrierCost.ToString();
        }        
    }

    public void BuyBaskets()
    {
        if (sManager.totalApples >= basketCost)
        {
            sManager.totalBaskets += 1;
            sManager.totalApples -= basketCost;
            basketCost = 1 + (int)Math.Pow(2.0, (double)sManager.totalBaskets * 1.420);
            basketText.text = basketCost.ToString();
        }        
    }

    public void BuyShakers()
    {
        if (sManager.totalApples >= shakerCost)
        {
            sManager.totalShakers += 1;
            sManager.totalApples -= shakerCost;
            shakerCost = 1 + (int)Math.Pow(2.0, (double)sManager.totalShakers * 1.69420);
            shakerText.text = shakerCost.ToString();
        }        
    }
}
