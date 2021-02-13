using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    // Object To Spawn
    public GameObject objToSpawn;

    private void Update()
    {

    }

    void OnMouseDown()
    {
        Debug.Log("Sprite Clicked");

        // Grow then Shrink Object
        transform.localScale = transform.localScale + new Vector3(0.1f, 0.1f, 0);
        Invoke("ScaleObject", 0.5f);

        // Spawn Apple
        spawnObject();
    }

    void ScaleObject()
    {
        // Transform (Shrink)
        transform.localScale = transform.localScale + new Vector3(-0.1f, -0.1f, 0);
    }

    public void spawnObject()
    {
        // Spawn Location
        Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        clickPosition.z = 0;
        // Spawn Object
        Instantiate(objToSpawn, clickPosition, Quaternion.identity);
    }
}