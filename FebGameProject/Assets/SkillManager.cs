using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    private float nextActionTime = 0.0f;

    private float nATskill1 = 0.0f;

    public Transform attackPos;

    private int slotIndex;
    public Skills starterSkill;

    public int slots = 3;

    //SkillUI
    public GameObject skillInventory;
    // Start is called before the first frame update
    void Start()
    {
        AddSkill(starterSkill);
        slotIndex = skillInventory.GetComponent<SkillInventory>().selectedIndex;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            if (slotIndex <= 0)
            {
                SwapSlot(slotIndex);
            }
            else
            {
                slotIndex--;
                SwapSlot(slotIndex);
            }

        }
        else if (Input.GetKeyDown("x"))
        {
            if (slotIndex >= slots - 1)
            {
                SwapSlot(slotIndex);
            }
            else
            {
                slotIndex++;
                SwapSlot(slotIndex);
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {

            SkillSlot slot = skillInventory.GetComponent<SkillInventory>().slots[skillInventory.GetComponent<SkillInventory>().selectedIndex].GetComponent<SkillSlot>();
            if (slot.currentSkill != null)
            {

                if (slot.isCoolingDown)
                {

                }
                else
                {
                    CastSkill(slot.currentSkill);
                    Debug.Log("START CD");
                    slot.isCoolingDown = true;
                    slot.coolDownTime = slot.currentSkill.cooldown;
                    slot.coolDownTimer = slot.coolDownTime;
                }

            }


        }
    }

        public void CastSkill(Skills skill)
    {
        Debug.Log("Player attacked using " + skill.name);
        GameObject newBullet = (GameObject)Instantiate(skill.skillBullet, attackPos.position, attackPos.rotation);
        Destroy(newBullet, 2f);
    }


    public void AddSkill(Skills skill)
    {
        Debug.Log("Skill being added");

        bool found = false;
        foreach(GameObject slot in skillInventory.GetComponent<SkillInventory>().slots)
        {
            if(slot.GetComponent<SkillSlot>().currentSkill == skill)
            {
                found = true;
            }
        }
        if (!found)
        {
            bool available = false;
            foreach (GameObject slot in skillInventory.GetComponent<SkillInventory>().slots)
            {
                if (slot.GetComponent<SkillSlot>().currentSkill == null)
                {
                    available = true;
                    slot.GetComponent<SkillSlot>().AssignSkill(skill);
                    break;
                }
            }
            if (!available)
            {
                Debug.Log("Max skills reached");
            }
        }
        



    }

    public void SwapSlot(int i)
    {
        skillInventory.GetComponent<SkillInventory>().selectedIndex = i;
        skillInventory.GetComponent<SkillInventory>().HighlightSelectedIndex();
    }

}
