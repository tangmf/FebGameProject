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
    public GameObject alertIcon;
    // Start is called before the first frame update
    void Start()
    {
        animator = entity.gameObject.GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = entity.gameObject.GetComponent<SpriteRenderer>();
        alertIcon.SetActive(false);
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
            alertIcon.SetActive(true);

        }

    }

    void OnTriggerExit2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player"))
        {
            animator.SetBool("PlayerDetect", false);
            playerDetect = false;
            alertIcon.SetActive(false);
        }

    }

    void Shoot()
    {
        GameObject newBullet = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Destroy(newBullet, 2f);

    }


}
