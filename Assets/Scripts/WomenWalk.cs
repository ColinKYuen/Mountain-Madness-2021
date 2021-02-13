using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomenWalk : MonoBehaviour
{
    private Vector3 directionVector;
    private Transform myTransform;
    public float speed;
    private Rigidbody2D rb;
    private Animator anim;
    public Collider2D bounds;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        ChangeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
   
    
    private void Move()
    {
        Vector3 temp = myTransform.position + directionVector * speed * Time.deltaTime;
        if (bounds.bounds.Contains(temp))
        {
            rb.MovePosition(temp);
        }
        else
        {
            ChangeDirection();  
        }
        
    }

    void ChangeDirection()
    {
        int direction = Random.Range(0, 1);
        switch(direction)
        {
            case 0: // walk right
                directionVector = Vector3.right;
                break;
            case 1: //walk left
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector3 temp = directionVector;
        ChangeDirection();
        int loops = 0;
        while(temp == directionVector && loops < 100)
        {
            print("Collided");
            loops++;
            ChangeDirection();
        }
    }
}
