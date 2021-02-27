using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5f;
    public int jumpForce = 10;
    public bool isGrounded = false;
    Rigidbody2D rb2d;

    Animator animator;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2d.velocity = new Vector2(Speed, rb2d.velocity.y);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2d.velocity = new Vector2(-Speed, rb2d.velocity.y);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        if (Input.GetKey("w") && isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
  
        }
        if (isGrounded == false)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

    }


}
