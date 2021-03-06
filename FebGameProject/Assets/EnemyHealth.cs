using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int healthPoints = 100;
    public GameObject entity;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        healthPoints -= damage;
        if (healthPoints <= 0)
        {
            healthPoints = 0;
            Die();
        }
        UpdateHealth();

    }

    public void Die()
    {
        Destroy(entity);
        Debug.Log(entity.ToString() + " has been killed");
    }
    public void UpdateHealth()
    {
        slider.value = healthPoints;
    }
}
