using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public int heal = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        HealthManager player = hitInfo.GetComponent<HealthManager>();
        if (player != null)
        {
            if(player.healthPoints < 100)
            {
                Destroy(gameObject);
                player.Heal(heal);
            }
        }
    }
}
