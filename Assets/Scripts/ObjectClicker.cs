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
        spawnObject();
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