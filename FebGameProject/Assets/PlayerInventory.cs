using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<Item> itemList = new List<Item>();
    public Transform handPos;
    public SpriteRenderer spriteRenderer;
    public Item currentItem;

    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    public Transform attackPos;
    public float attackRange;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            if (Input.GetKey(KeyCode.Space))
            {

                if (itemList.Count == 0)
                {
                    Debug.Log("no weapon");
                }
                else
                {

                    Debug.Log("Player attacked using " + currentItem.name);
                }

                nextActionTime += period;
            }
        }

        if (Input.GetKey("1"))
        {
            SwapWeapon(0);
            UpdateCurrentItemSprite();
        }
        else if (Input.GetKey("2"))
        {
            SwapWeapon(1);
            UpdateCurrentItemSprite();
        }

        if (Input.GetKey("q") && currentItem != null)
        {
            DropCurrentItem();
        }
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
        currentItem = item;
        UpdateCurrentItemSprite();
    }

    public void ListAllItems()
    {
        foreach(Item i in itemList)
        {
            Debug.Log(i.name);
        }
    }

    public void SwapWeapon(int i)
    {
        currentItem = itemList[i];
    }

    public void UpdateCurrentItemSprite()
    {
        spriteRenderer.sprite = currentItem.itemSprite;
    }

    public void DropCurrentItem()
    {
        itemList.Remove(currentItem);
        Instantiate(currentItem.droppedItem, handPos.position, handPos.rotation);
        currentItem = null;
        spriteRenderer.sprite = null;
    }
}
