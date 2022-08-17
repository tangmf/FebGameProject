using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBox : MonoBehaviour
{
    public Item currentItem;
    public GameObject backImage;
    public GameObject displayImage;
    public Text quantity;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(Item item, int qty)
    {
        if (item != null)
        {
            currentItem = item;
            displayImage.GetComponent<Image>().sprite = item.itemSprite;
            quantity.text = qty.ToString();
            Debug.Log("Item Successfully added");
        }

    }
    public void AddItemStack(Item item, int qty)
    {
        int originalqty = int.Parse(quantity.text);
        quantity.text = (originalqty + qty).ToString();
    }
    public void RemoveItem(Item item, int qty)
    {
        currentItem = null;
        displayImage.GetComponent<Image>().sprite = null;
        quantity.text = "0";
        Debug.Log("Item Successfully removed");
    }
    public void RemoveItemStack(Item item, int qty)
    {
        int originalqty = int.Parse(quantity.text);
        quantity.text = (originalqty - qty).ToString();
    }
    public void Highlight()
    {
        backImage.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
    }
    public void DeHighlight()
    {
        backImage.GetComponent<Image>().color = new Color32(255, 255, 225, 0);
    }

}
