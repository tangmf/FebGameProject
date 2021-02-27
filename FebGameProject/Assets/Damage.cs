using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public Rigidbody2D rb;
    public int damage = 40;
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
        HealthManager player = hitInfo.GetComponent<HealthManager>();
        if (player != null)
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }

    }
}
