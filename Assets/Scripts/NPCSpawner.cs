using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    // NPCs to spawn
    public GameObject NPC1;
    public GameObject NPC2;
    public GameObject NPC3;
    public GameObject NPC4;
    List<GameObject> npcList = new List<GameObject>();

    private ScoreManager sManager;
    float spawnTimer;
    float timer = 0f;

    void Start()
    {
        sManager = ScoreManager.Instance;
        spawnTimer = Random.Range(1f, 2f);
        npcList.Add(NPC1);
        npcList.Add(NPC2);
        npcList.Add(NPC3);
        npcList.Add(NPC4);
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > spawnTimer) {
            spawnNPC();
            timer = 0;
        }
    }

    public void spawnNPC()
    {
        // Spawn NPCS
        for (int i = 0; i < sManager.totalCarriers; i++) {
            int prefabIndex = UnityEngine.Random.Range(0, 4);
            Instantiate(npcList[prefabIndex], new Vector3(-48.92f - (3f * i), 90.73997f, 0f), Quaternion.identity);
        }
        timer = 0f;
        spawnTimer = Random.Range(3f, 6f);
    }
}
