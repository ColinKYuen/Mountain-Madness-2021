using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleClicker : MonoBehaviour
{
    private ScoreManager sManager;
    private AudioSource audiosource;
    private bool hasFallen = false;
    private bool hasBeenClicked = false;
    
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }
    
    void OnMouseDown()
    {
        Debug.Log("Apple Clicked");
        // Only allow clicking the Apple once it has fallen
        if (hasFallen && !hasBeenClicked) {
            hasBeenClicked = true;
            sManager = ScoreManager.Instance;
            sManager.totalApples += 1;        
            audiosource.PlayOneShot(audiosource.clip);
            GetComponent<Renderer>().enabled = false;
            Destroy(gameObject, audiosource.clip.length);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Determine if Apple has fallen
        Debug.Log(col.name);
        if (col.gameObject.tag == "Ground") {
            hasFallen = true;
        }
    }
}
