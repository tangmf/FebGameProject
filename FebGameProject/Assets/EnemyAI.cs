﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb2d;
    public bool playerDetect = false;
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

    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        animator.SetBool("PlayerDetect", true);
        playerDetect = true;
        FollowPlayer targetPlayer = this.GetComponent<FollowPlayer>();
        targetPlayer.TargetPlayer();
        
    }

    void OnTriggerExit2D(Collider2D hitInfo)
    {
        animator.SetBool("PlayerDetect", false);
        playerDetect = false;
    }

}
