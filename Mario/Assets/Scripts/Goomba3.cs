using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba3 : MonoBehaviour
{

    private Animator anim;
    private bool playerHit;
    private bool facingRight = true;
    public float walkSpeed = 1.0f;      // Walkspeed
    public float wallLeft = 0.0f;       // Define wallLeft
    public float wallRight = 5.0f;      // Define wallRight
    float walkingDirection = 1.0f;
    Vector2 walkAmount;
    float originalX; // Original float value


    void Start()
    {
        this.originalX = this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
        if (walkingDirection > 0.0f && transform.position.x >= originalX + wallRight)
        {
            walkingDirection = -1.0f;
            Flip();
        }
        else if (walkingDirection < 0.0f && transform.position.x <= originalX - wallLeft)
        {
            walkingDirection = 1.0f;
            Flip();
        }
        transform.Translate(walkAmount);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }
    void Dead()
    {
        Destroy(gameObject);
        


    }

    

}

   



