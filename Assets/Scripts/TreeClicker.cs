using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeClicker : MonoBehaviour
{
    public GameObject objToSpawn;
    private AudioSource audiosource;
    float treeScaleFactor = 0.1f;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.time = audiosource.clip.length * .9f;
    }

    void OnMouseDown()
    {
        // Grow then Shrink tree on click
        transform.localScale = transform.localScale + new Vector3(treeScaleFactor, treeScaleFactor, 0);
        Invoke("ScaleObject", 0.5f);

        // Spawn Apple
        spawnObject();
        audiosource.Play();
    }

    void ScaleObject()
    {
        // Transform (Shrink)
        transform.localScale = transform.localScale + new Vector3(-treeScaleFactor, -treeScaleFactor, 0);
    }

    public void spawnObject()
    {
        // Only spawn on some percentage of clicks
        if (Random.value > 0.58f) {
            return;
        }

        // Spawn Location
        Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        clickPosition.z = 0;
        // Spawn Object
        Instantiate(objToSpawn, clickPosition, Quaternion.identity);
    }
}
