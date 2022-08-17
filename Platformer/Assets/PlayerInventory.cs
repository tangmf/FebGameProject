using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public int maxSlots = 2;
    public GameObject inventoryUI;
    public Text inventoryList;
    public Text inventoryDesc;
    public Image inventoryItemSprite;
    public Text inventoryItemAtk;
    public Text inventoryItemDef;
    public HealthManager healthManager;

    // Start is called before the first frame update
    void Start()
    {
        inventoryUI.SetActive(false);
        HealthManager stats = healthManager.GetComponent<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                if (itemList.Count == 0)
                {
                    
                    Debug.Log("no weapon");
                    nextActionTime += period;
                }
                else
                {
                    
                    Debug.Log("Player attacked using " + currentItem.name);
                    GameObject newBullet = (GameObject)Instantiate(currentItem.bullet, attackPos.position, attackPos.rotation);
                    Destroy(newBullet, 2f);
                    nextActionTime += period;
                }

                
            }
        }
        /*
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
        */
        if (Input.GetKey("q") && currentItem != null)
        {
            DropCurrentItem();
            UpdateInventoryList();
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
        HealthManager stats = healthManager.GetComponent<HealthManager>();
        itemList.Add(item);
        currentItem = item;
        stats.defence += item.defence;
        stats.damage += item.damage;
        UpdateCurrentItemSprite();
        UpdateInventoryList();
    }

    public void ListAllItems()
    {
        foreach(Item i in itemList)
        {
            Debug.Log(i.name);
        }
    }
    /*
    public void SwapWeapon(int i)
    {
        currentItem = itemList[i];
    }
    */
    public void UpdateCurrentItemSprite()
    {
        spriteRenderer.sprite = currentItem.itemSprite;
    }

    public void DropCurrentItem()
    {
        HealthManager stats = healthManager.GetComponent<HealthManager>();
        itemList.Remove(currentItem);
        inventoryItemSprite.sprite = null;
        inventoryDesc.text = null;
        inventoryItemAtk.text = null;
        inventoryItemDef.text = null;
        Instantiate(currentItem.droppedItem, handPos.position, handPos.rotation);
        stats.defence -= currentItem.defence;
        stats.damage -= currentItem.damage;
        currentItem = null;
        spriteRenderer.sprite = null;
        UpdateInventoryList();

    }

    public void CloseInventory()
    {
        inventoryUI.SetActive(false);
    }

    public void UpdateInventoryList()
    {
        inventoryList.text = "";
        /*
        foreach (Item i in itemList)
        {
            inventoryList.text = inventoryList.text + i.name;
        }
        */
        inventoryList.text = currentItem.name;
        inventoryDesc.text = currentItem.desc;
        inventoryItemDef.text = "+ " + currentItem.defence + " defence";
        inventoryItemAtk.text = "+ " + currentItem.damage + " damage";
    }

}
