using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public GameObject entity;
    public int healthPoints = 100;
    public Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        healthText.text = healthPoints.ToString();
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
    }

    public void TakeDamage(int damage)
    {
        healthPoints -= damage;
        if(healthPoints <= 0)
        {
            healthPoints = 0;
            healthText.text = healthPoints.ToString();
            Die();
        }
        else
        {
            healthText.text = healthPoints.ToString();
        }
    }

    public void Die()
    {
        Destroy(entity);
        Debug.Log(entity.ToString() + " has been killed");
    }

}
