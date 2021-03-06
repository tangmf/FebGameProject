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
    public int damage;


    void Start()
    {
        // Move the bullet
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("ignore"))
        {
            return;
        }
        else
        {
            if (hitInfo.CompareTag("Enemy"))
            {
                EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }
            // Play Collide animation
            animator.Play(collideAnimationName);

            // Stop moving the bullet
            rb.velocity = Vector3.zero;

            // Destroy after animations length (sec)
            Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
        }


    }
}
