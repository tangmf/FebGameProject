using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public Rigidbody2D rb;
    public int damage = 40;
    public bool hurtPlayer = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player"))
        {
            HealthManager player = hitInfo.GetComponent<HealthManager>();
            if (player != null && hurtPlayer)
            {
                player.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
        else if (hitInfo.CompareTag("Enemy"))
        {
            EnemyAI enemy = hitInfo.GetComponent<EnemyAI>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
        

    }
}
