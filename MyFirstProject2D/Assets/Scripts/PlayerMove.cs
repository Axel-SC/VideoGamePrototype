using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float runSpeed = 2;
    public float jumpSpeed = 3;

    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    Animator animator;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        animator.SetBool("isJumping", false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            pos.x += runSpeed * Time.deltaTime;
            spriteRenderer.flipX = false;
            animator.SetBool("isRunning", true);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            pos.x -= runSpeed * Time.deltaTime;
            spriteRenderer.flipX = true;
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if((Input.GetKey("w") || Input.GetKey("space")) && CheckGround.isGrounded){
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
            animator.SetBool("isJumping", true);
            animator.SetBool("isRunning", false);
        }

        if (CheckGround.isGrounded == true && rb2d.velocity.y <=0)
        {
            animator.SetBool("isJumping", false);
        }
        
      
        transform.position = pos;
    }
}
