using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    private float nextActionTime = 0.0f;

    private float nATskill1 = 0.0f;

    public Transform attackPos;
    public List<Skills> skillList = new List<Skills>();
    public Skills currentSkill;

    public Skills starterSkill;

    public int slots = 3;

    //SkillUI
    public Image skillIcon1;
    public Image skillIcon2;
    public Image skillIcon3;
    public Image skillBackground1;
    public Image skillBackground2;
    public Image skillBackground3;
    // Start is called before the first frame update
    void Start()
    {
        skillList.Add(starterSkill);
        if (skillList.Count != 0)
        {
            currentSkill = starterSkill;
        }
        UpdateSkillUI();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("1"))
        {
            SwapSkill(skillList[0]);
        }
        else if (Input.GetKey("2"))
        {
            SwapSkill(skillList[1]);
        }
        else if (Input.GetKey("3"))
        {
            SwapSkill(skillList[2]);
        }

        if (Time.time > nextActionTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                nextActionTime = Time.time + currentSkill.cooldown;
                if (currentSkill != null)
                {
                    CastSkill(currentSkill);

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

    public void SwapSkill(Skills skill)
    {
        UpdateSkillUI();
        currentSkill = skill;
        nextActionTime = Time.time + skill.cooldown;
    }

    public void AddSkill(Skills skill)
    {
        Debug.Log("Skill being added");
        if (skillList.Count != slots)
        {
            bool exists = false;
            foreach(Skills s in skillList)
            {
                if(s == skill)
                {
                    exists = true;
                }
            }
            if (exists)
            {
                Debug.Log("Already have this skill");
            }
            else
            {
                skillList.Add(skill);
                UpdateSkillUI();
            }
            
        }
        else
        {
            Debug.Log("Max skills reached");
        }

    }

    public void UpdateSkillUI()
    {
        skillIcon1.sprite = skillList[0].skillIcon;
        skillIcon2.sprite = skillList[1].skillIcon;
        skillIcon3.sprite = skillList[2].skillIcon;
    }

}
