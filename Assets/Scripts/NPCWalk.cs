// Moves NPCs across screen

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWalk : MonoBehaviour
{
    public float speed;
    ScoreManager sManager;
    new Transform transform;
    Animator anim;
    int applesPicked = 0;

    void Start()
    {
        applesPicked = 0;
        sManager = ScoreManager.Instance;
        transform = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // Move NPCs at a constant pace
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
    }

    void UpdateAnimation()
    {
        anim.SetFloat("MoveX", Vector2.right.x);
        anim.SetFloat("MoveY", Vector2.right.y);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Apple" && applesPicked < sManager.totalBaskets) {
            Destroy(col.gameObject);
            applesPicked += 1;
            sManager.totalApples += 1;
        } else if (col.gameObject.tag == "Border") {
            Destroy(gameObject);
        }
    }
}
