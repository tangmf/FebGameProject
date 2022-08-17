using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour
{
    public Skills currentSkill;
    public GameObject backImage;
    public GameObject displayImage;
    public Slider coolDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AssignSkill(Skills skill)
    {
        if (skill != null)
        {
            currentSkill = skill;
            displayImage.GetComponent<Image>().sprite = skill.skillIcon;
            Debug.Log("Skill Successfully added");
        }

    }

    public void RemoveSkill()
    {
        currentSkill = null;
        displayImage.GetComponent<Image>().sprite = null;
        Debug.Log("Skill Successfully removed");
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
