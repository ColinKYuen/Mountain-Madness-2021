using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeClicker : MonoBehaviour
{
    // Object To Spawn
    public GameObject objToSpawn;
    public GameObject NPC;
    public GameObject NPC2;
    public GameObject NPC3;
    public GameObject NPC4;
    List<GameObject> npcList = new List<GameObject>();

    private AudioSource audiosource;

    float spawnTimer;
    float timer = 0f;
    private ScoreManager sManager;


    void Start()
    {
        spawnTimer = Random.Range(1f, 1.5f);
        sManager = ScoreManager.Instance;
        npcList.Add(NPC);
        npcList.Add(NPC2);
        npcList.Add(NPC3);
        npcList.Add(NPC4);
        audiosource = GetComponent<AudioSource>();
        audiosource.time = audiosource.clip.length * .9f;
    }

    void FixedUpdate()
    {
        
        timer += Time.deltaTime;
        if (timer > spawnTimer) {
            spawnNPC();
            timer = 0;
        }
        
    }

    void OnMouseDown()
    {
        Debug.Log("Sprite Clicked");

        // Grow then Shrink Object
        transform.localScale = transform.localScale + new Vector3(0.1f, 0.1f, 0);
        Invoke("ScaleObject", 0.5f);

        // Spawn Apple
        spawnObject();
        audiosource.Play();
    }

    void ScaleObject()
    {
        // Transform (Shrink)
        transform.localScale = transform.localScale + new Vector3(-0.1f, -0.1f, 0);
    }

    public void spawnObject()
    {
        bool trueOrFalse = (Random.value > 0.58f);
        if (trueOrFalse) {
            return;
        }

        // Spawn Location
        Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        clickPosition.z = 0;
        // Spawn Object
        Instantiate(objToSpawn, clickPosition, Quaternion.identity);
    }

    public void spawnNPC()
    {
        // Spawn NPCS
        for (int i = 0; i < sManager.totalCarriers; i++) {
            print("Spawned NPC");
            int prefabIndex = UnityEngine.Random.Range(0, 4);
            Instantiate(npcList[prefabIndex], new Vector3(-48.92f, 90.73997f, 0f), Quaternion.identity);
        }
        timer = 0f;
        spawnTimer = Random.Range(3f, 6f);
    }

 
}
