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
    public LayerMask breakableLayers;

    public Item fist;

    // Start is called before the first frame update
    void Start()
    {
        buildManager = GetComponent<BuildManager>();
        slotsContainer.GetComponent<Inventory>().Initialize();
        maxSlots = slotsContainer.GetComponent<Inventory>().totalSlots;
        //UpdateBuildManager();
        AddItem(fist);
        inventoryUI.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown("1"))
        {
            SwapSlot(0);
        }
        else if (Input.GetKeyDown("2"))
        {
            SwapSlot(1);
        }
        else if (Input.GetKeyDown("3"))
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

        if (Input.GetButtonDown("Fire1"))
        {
            if(GetCurrentItem() != null)
            {

                    UseCurrentItem();
                    buildManager.Activate(GetCurrentItem());



                UpdateBuildManager();
            }


        }
    }

    public void AddItem(Item item)
    {

        AddItemToInventory(item, 1);
        UpdateBuildManager();
        
    }




    public void DropCurrentItem()
    {
        Item item = GetCurrentItem();
        if (item.canDrop)
        {
            RemoveItemFromInventory(item, 1);

            Instantiate(item.droppedItem, handPos.position, handPos.rotation);

            UpdateBuildManager();
        }

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
            int quantity = int.Parse(slotObject.quantity.text.ToString());
            if (slotObject.currentItem == item && quantity < item.maxStack)
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
                    slotObject.RemoveItem(item);
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
        
        UpdateBuildManager();
    }

    public Item GetCurrentItem()
    {
        return slotsContainer.GetComponent<Inventory>().slots[slotsContainer.GetComponent<Inventory>().selectedIndex].GetComponent<InventoryBox>().currentItem;
    }

    public void UseCurrentItem()
    {
        int itemQty = int.Parse(GetCurrentItemSlot().quantity.text.ToString());
        if (itemQty <= 0)
        {

            
        }
        else
        {
            // Use
            if (GetCurrentItem().type == "Block")
            {
                buildManager.Activate(GetCurrentItem());
                if (buildManager.tilePainter.GetComponent<TilePainter>().PaintTileInstant())
                {
                    // Remove from inventory
                    RemoveItemFromInventory(GetCurrentItem(), 1);
                }
                    
            }
            else if(GetCurrentItem().type == "Breaker")
            {
                Debug.Log("Break");
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D target = Physics2D.OverlapPoint(mousePosition, breakableLayers);
                if (target)
                {
                    if (target.GetComponent<Block>())
                    {
                        target.GetComponent<Block>().BreakBlock();
                    }
                }


            }
            else if(GetCurrentItem().type == "Bullet")
            {
                Debug.Log("SHOOT");
                GameObject newBullet = (GameObject)Instantiate(GetCurrentItem().bullet, attackPos.position, attackPos.rotation);
                Destroy(newBullet, 2f);
            }
            
            UpdateBuildManager();
        }
        
    }

    public InventoryBox GetCurrentItemSlot()
    {
        return slotsContainer.GetComponent<Inventory>().slots[slotsContainer.GetComponent<Inventory>().selectedIndex].GetComponent<InventoryBox>();
    }

    public void UpdateBuildManager()
    {
        takenSlots = slotsContainer.GetComponent<Inventory>().GetTakenSlots();
        slotsContainer.GetComponent<Inventory>().HighlightSelectedIndex();
        if (GetCurrentItem() != null)
        {
            spriteRenderer.sprite = GetCurrentItem().itemSprite;
        }
        else
        {
            spriteRenderer.sprite = null;
        }

        int itemQty = int.Parse(GetCurrentItemSlot().quantity.text.ToString());
        if (itemQty != 0)
        {
            if (GetCurrentItem().type == "Block")
            {
                buildManager.Activate(GetCurrentItem());
            }
            else
            {
                buildManager.DeActivate();
            }
        }
        else
        {
            buildManager.DeActivate();
        }
        buildManager.tilePainter.GetComponent<TilePainter>().ResetPreview();


    }

    public bool CanTakeItem(Item item)
    {
        if(takenSlots < maxSlots)
        {
            return true;
        }
        else
        {
            List<GameObject> slotList = slotsContainer.GetComponent<Inventory>().slots;
            foreach (GameObject slot in slotList)
            {
                InventoryBox slotObject = slot.GetComponent<InventoryBox>();
                int quantity = int.Parse(slotObject.quantity.text.ToString());
                if (slotObject.currentItem == item && quantity < item.maxStack)
                {
                    return true;
                }

            }
        }
        
        return false;
    }
}
