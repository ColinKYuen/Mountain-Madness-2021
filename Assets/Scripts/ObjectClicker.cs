using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    // Object To Spawn
    public GameObject objToSpawn;
    public GameObject NPC;
    public GameObject NPC2;
    public GameObject NPC3;
    public GameObject NPC4;
    List<GameObject> npcList = new List<GameObject>();


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

        //Spawn NPCS
        npcList.Add(NPC);
        npcList.Add(NPC2);
        npcList.Add(NPC3);
        npcList.Add(NPC4);

        int prefabIndex = UnityEngine.Random.Range(0, 4);
        Instantiate(npcList[prefabIndex], new Vector3(-48.92f, 90.73997f, 0f), Quaternion.identity);
    }
}