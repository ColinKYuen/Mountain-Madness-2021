using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleClicker : MonoBehaviour
{
    private ScoreManager sManager;
    private AudioSource audiosource;
    private bool hasFallen = false;
    
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }
    
    void OnMouseDown()
    {
        // Only allow clicking the Apple once it has fallen
        if (hasFallen) {
            sManager = ScoreManager.Instance;
            Debug.Log("Apple Clicked");
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
            Debug.Log("Apple Fell");
        }
    }
}
