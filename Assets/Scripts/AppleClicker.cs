using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleClicker : MonoBehaviour
{
    private ScoreManager sManager;
    private AudioSource audiosource;
    
    void Start() {
        audiosource = GetComponent<AudioSource>();
    }
    
    void OnMouseDown()
    {
        sManager = ScoreManager.Instance;
        Debug.Log("Apple Clicked");        
        sManager.totalApples += 1;        
        audiosource.PlayOneShot(audiosource.clip);
        GetComponent<Renderer>().enabled = false;
        Destroy(gameObject, audiosource.clip.length);
    }
}
