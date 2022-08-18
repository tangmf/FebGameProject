using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public Transform handPos;
    public SpriteRenderer spriteRenderer;

    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    public Transform attackPos;
    public float attackRange;

    public int maxSlots = 3;
    public int takenSlots = 0;
    public GameObject inventoryUI;
    private BuildManager buildManager;

    public GameObject slotsContainer;

    // Start is called before the first frame update
    void Start()
    {
        buildManager = GetComponent<BuildManager>();
        slotsContainer.GetComponent<Inventory>().Initialize();
        inventoryUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey("1"))
        {
            SwapSlot(0);
        }
        else if (Input.GetKey("2"))
        {
            SwapSlot(1);
        }
        else if (Input.GetKey("3"))
        {
            SwapSlot(2);
        }

        if (Input.GetKeyDown("q"))
        {
            DropCurrentItem();

        }

        if (Input.GetKeyDown("i"))
        {
            if(inventoryUI.activeSelf)
            {
                inventoryUI.SetActive(false);
                Debug.Log("Inventory closed");
            }
            else
            {
                inventoryUI.SetActive(true);
                Debug.Log("Inventory opened");
            }
            
            
        }
    }

    public void AddItem(Item item)
    {

        AddItemToInventory(item, 1);
        
    }




    public void DropCurrentItem()
    {
        Item item = slotsContainer.GetComponent<Inventory>().slots[slotsContainer.GetComponent<Inventory>().selectedIndex].GetComponent<InventoryBox>().currentItem;
        RemoveItemFromInventory(item, 1);

        Instantiate(item.droppedItem, handPos.position, handPos.rotation);

    }

    public void CloseInventory()
    {
        inventoryUI.SetActive(false);
    }


    public void AddItemToInventory(Item item, int qty)
    {
        bool continue1 = true;
        List<GameObject> slotList = slotsContainer.GetComponent<Inventory>().slots;
        foreach (GameObject slot in slotList)
        {
            InventoryBox slotObject = slot.GetComponent<InventoryBox>();
            if (slotObject.currentItem == item)
            {
                slotObject.AddItemStack(item, qty);
                continue1 = false;
                break;
            }

        }

        if (continue1){

            foreach (GameObject slot in slotList)
            {
                InventoryBox slotObject = slot.GetComponent<InventoryBox>();
                if (slotObject.currentItem == null)
                {
                    slotObject.AddItem(item, qty);
                    break;
                }

            }
        }
        
        Debug.Log("Item Added: " + item.name);
    }

    public void RemoveItemFromInventory(Item item, int qty)
    {
        List<GameObject> slotList = slotsContainer.GetComponent<Inventory>().slots;
        foreach (GameObject slot in slotList)
        {
            InventoryBox slotObject = slot.GetComponent<InventoryBox>();
            if (slotObject.currentItem == item)
            {
                int quantity = int.Parse(slotObject.quantity.text.ToString());
                if (quantity > 1)
                {
                    slotObject.RemoveItemStack(item, qty);
                }
                else
                {
                    slotObject.RemoveItem(item, qty);
                    spriteRenderer.sprite = null;
                }
                
                break;
            }

        }
        Debug.Log("Item Removed: " + item.name);
    }

    public void SwapSlot(int i)
    {


        slotsContainer.GetComponent<Inventory>().selectedIndex = i;
        slotsContainer.GetComponent<Inventory>().HighlightSelectedIndex();
        spriteRenderer.sprite = GetCurrentItem().itemSprite;
        if(GetCurrentItem().type == "Block")
        {
            buildManager.Activate(GetCurrentItem());
        }
        else
        {
            buildManager.DeActivate();
        }
    }

    public Item GetCurrentItem()
    {
        return slotsContainer.GetComponent<Inventory>().slots[slotsContainer.GetComponent<Inventory>().selectedIndex].GetComponent<InventoryBox>().currentItem;
    }

}
