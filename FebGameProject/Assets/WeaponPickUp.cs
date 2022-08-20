using System.Collections;
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

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            PlayerInventory playerInventory = hitInfo.GetComponent<PlayerInventory>();

            if (playerInventory.CanTakeItem(item))
            {
                Destroy(gameObject);
                Debug.Log(item.name + " Picked up");
                playerInventory.AddItem(item);
            }
            else
            {
                Debug.Log("Inventory full");
            }
            /*
            if (playerInventory != null)
            {
                if(playerInventory.takenSlots < playerInventory.maxSlots)
                {
                    Destroy(gameObject);
                    Debug.Log(item.name + " Picked up");
                    playerInventory.AddItem(item);
                }
                else
                {
                    Debug.Log("Inventory full");
                }
                

            }
            */
            
        }
    }

}
