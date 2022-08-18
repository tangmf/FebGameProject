using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : MonoBehaviour
{
    public GameObject item;
    public int count = 30;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Player" && Input.GetKeyDown("e"))
        {
            if(count > 0)
            {
                Instantiate(item, spawnPoint.position, spawnPoint.rotation);
                count--;
            }
            
        }

    }
}
