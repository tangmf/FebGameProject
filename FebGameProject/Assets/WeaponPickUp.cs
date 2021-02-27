﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public Item item;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = item.itemSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            HealthManager player = hitInfo.GetComponent<HealthManager>();
            if (player != null)
            {
                Debug.Log(item.name + " Picked up");
            }
            Destroy(gameObject);
        }
    }

}
