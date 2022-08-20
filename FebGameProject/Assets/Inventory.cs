using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> slots;
    public int selectedIndex;
    public int totalSlots;

    // Start is called before the first frame update
    void Start()
    {

        ResetSlots();
        selectedIndex = 0;
        HighlightSelectedIndex();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HighlightSelectedIndex()
    {
        ResetSlots();
        slots[selectedIndex].GetComponent<InventoryBox>().Highlight();
    }

    void ResetSlots()
    {
        foreach (GameObject slot in slots)
        {
            slot.GetComponent<InventoryBox>().DeHighlight();
        }
    }

    public void Initialize()
    {
        foreach (Transform slot in transform)
        {
            slots.Add(slot.gameObject);
            Debug.Log("Slot loaded " + slots.Count.ToString());
        }
        totalSlots = slots.Count;
    }

    public int GetTakenSlots()
    {
        int count = 0;
        foreach (GameObject slot in slots)
        {
            if(slot.GetComponent<InventoryBox>().currentItem != null)
            {
                count++;
            }
        }
        Debug.Log("Slots taken: " + count.ToString());
        return count;
    }
}
