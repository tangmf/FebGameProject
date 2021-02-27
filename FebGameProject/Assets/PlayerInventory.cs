using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<Item> itemList = new List<Item>();
    public Transform handPos;
    public SpriteRenderer spriteRenderer;
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
        spriteRenderer.sprite = item.itemSprite;
    }
}
