using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWalk : MonoBehaviour
{
    private ScoreManager sManager;
    private Vector3 directionVector;
    private Transform myTransform;
    public float speed;
    private Rigidbody2D rb;
    private Animator anim;
    public Collider2D bounds;
    bool applePicked = false;

    int applePickup; // how many apples each NPC can pick up

    void Start()
    {
        sManager = ScoreManager.Instance;
        anim = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        ChangeDirection();
        applePickup = sManager.totalBaskets;
    }

    void FixedUpdate()
    {
        // Move NPCs at a constant pace
        Move();
    }

    private void Move()
    {
        Vector3 temp = myTransform.position + directionVector * speed * Time.deltaTime;
        if (bounds.bounds.Contains(temp)) {
            rb.MovePosition(temp);
        } else {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        int direction = Random.Range(0, 1);
        switch(direction) {
            case 0: // walk right
                directionVector = Vector3.right;
                break;
            case 1: // walk left
                directionVector = Vector3.left;
                break;
            default:
                break;
        }
    }

    void UpdateAnimation()
    {
        anim.SetFloat("MoveX", directionVector.x);
        anim.SetFloat("MoveY", directionVector.y);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Vector3 temp = directionVector;
        ChangeDirection();
        int loops = 0;
        while (temp == directionVector && loops < 100) {
            if (!applePicked && col.gameObject.tag == "Apple") {
                if (applePickup > 1) {
                    Destroy(col.gameObject);
                    sManager.totalApples += 1;
                    applePickup -= 1;
                } else {
                    Destroy(col.gameObject);
                    applePicked = true;
                    sManager.totalApples += 1;
                }
            }
            loops++;
            ChangeDirection();
        }
    }
}
