﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public GameObject entity;
    public int healthPoints = 100;
    public int defence = 10;
    public int damage = 10;
    public Text healthText;

    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    public Transform attackPos;
    public float attackRange;
    public PlayerInventory playerInventory;
    public List<Item> items;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth();
        PlayerInventory items = playerInventory.GetComponent<PlayerInventory>();
    }

    void Update()
    {
        //for testing
        /*
        if (Input.GetButtonDown("Fire1"))
        {
            TakeDamage(10);

        }
        */

        if (Time.time > nextActionTime)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                PlayerInventory inventory = playerInventory.GetComponent<PlayerInventory>();

                if (inventory.itemList.Count == 0)
                {
                    Debug.Log("no weapon");
                }
                else
                {

                    Debug.Log("Player attacked using " + inventory.currentItem.name);
                }

                nextActionTime += period;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        healthPoints -= damage;
        if(healthPoints <= 0)
        {
            healthPoints = 0;
            UpdateHealth();
            Die();
        }
        else
        {
            UpdateHealth();
        }
    }

    public void Die()
    {
        Destroy(entity);
        Debug.Log(entity.ToString() + " has been killed");
    }

    public void Heal(int healAmt)
    {
        healthPoints += healAmt;
        if(healthPoints > 100)
        {
            healthPoints = 100;
        }
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        slider.value = healthPoints;
        healthText.text = healthPoints.ToString();
    }

}
