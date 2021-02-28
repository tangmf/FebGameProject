using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    public Transform attackPos;
    public float attackRange;
    public int damage;
    public PlayerInventory playerInventory;
    public List<Item> items;
    
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerInventory items = playerInventory.GetComponent<PlayerInventory>();

    }

    // Update is called once per frame
    void Update()
    {
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
                    Instantiate(inventory.currentItem.bullet, attackPos.position, attackPos.rotation);
                }
                
                nextActionTime += period;
            }
        }

    }


}
