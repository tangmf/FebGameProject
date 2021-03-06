using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public Animator animator;
    public string collideAnimationName;
    public Skills skill;


    void Start()
    {
        // Move the bullet
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        // If collides with something except player and spell
        if (hitInfo.name != "Player" && !hitInfo.name.Contains("Spell"))
        {
            // Play Collide animation
            animator.Play(collideAnimationName);

            // Stop moving the bullet
            rb.velocity = Vector3.zero;

            // Destroy after animations length (sec)
            Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
            
        }
    }
}
