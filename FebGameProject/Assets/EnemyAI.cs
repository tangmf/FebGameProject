using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb2d;
    public bool playerDetect = false;
    public GameObject entity;
    public Transform firePoint;
    private float nextActionTime = 0.0f;
    public float period = 1f;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        animator = entity.gameObject.GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = entity.gameObject.GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (playerDetect)
        {
            if (Time.time > nextActionTime)
            {
                nextActionTime = Time.time + period;
                Shoot();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player"))
        {
            animator.SetBool("PlayerDetect", true);
            playerDetect = true;
            FollowPlayer targetPlayer = entity.GetComponent<FollowPlayer>();
            targetPlayer.TargetPlayer();

        }

    }

    void OnTriggerExit2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player"))
        {
            animator.SetBool("PlayerDetect", false);
            playerDetect = false;
        }

    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }


}
