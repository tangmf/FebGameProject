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
    public bool isCoolingDown = false;
    public float coolDownTimer = 0.0f;
    public float coolDownTime;

    // Start is called before the first frame update
    void Start()
    {
        coolDown.value = 0;
        coolDownTime = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCoolingDown)
        {
            StartCoolDown();
        }
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

    public void StartCoolDown()
    {
        coolDownTimer -= Time.deltaTime;
        if(coolDownTimer < 0.0f)
        {
            Debug.Log("END CD");
            isCoolingDown = false;
            coolDown.value = 0;
        }
        else
        {
            coolDown.value = (coolDownTime -coolDownTimer) / coolDownTime * coolDown.maxValue;
        }
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
