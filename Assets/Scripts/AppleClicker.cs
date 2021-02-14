using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleClicker : MonoBehaviour
{
    private ScoreManager sManager;
    void OnMouseDown()
    {
        Debug.Log("Apple Clicked");
        sManager = ScoreManager.Instance;
        sManager.totalApples += 1;
        Destroy(gameObject);
    }
}
