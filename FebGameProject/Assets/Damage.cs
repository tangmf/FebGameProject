using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public Rigidbody2D rb;
    public int damage = 40;
    public Animator animator;
    public bool hurtPlayer = true;


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player"))
        {
            HealthManager player = hitInfo.GetComponent<HealthManager>();
            if (player != null && hurtPlayer)
            {
                // Play Collide animation
                animator.Play("Bomb_Explode");
                player.TakeDamage(damage);
                
                Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
            }
        }
        else if (hitInfo.CompareTag("Enemy"))
        {
            EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                // Play Collide animation
                animator.Play("Bomb_Explode");
                enemy.TakeDamage(damage);
                
                Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
            }
        }
        

    }
}
