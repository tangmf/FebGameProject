using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillInventory : MonoBehaviour
{
    public List<GameObject> slots;
    public int selectedIndex;

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
        slots[selectedIndex].GetComponent<SkillSlot>().Highlight();
    }

    void ResetSlots()
    {
        foreach (GameObject slot in slots)
        {
            slot.GetComponent<SkillSlot>().DeHighlight();
        }
    }

    public void Initialize()
    {
        foreach (Transform slot in transform)
        {
            slots.Add(slot.gameObject);
            Debug.Log("Skill slot loaded " + slots.Count.ToString());
        }
    }
}
