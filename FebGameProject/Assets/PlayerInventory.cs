using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<Item> itemList = new List<Item>();
    public Transform handPos;
    public SpriteRenderer spriteRenderer;
    public Item currentItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
        currentItem = item;
        spriteRenderer.sprite = item.itemSprite;
    }

    public void ListAllItems()
    {
        foreach(Item i in itemList)
        {
            Debug.Log(i.name);
        }
    }
}
