using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    private float nextActionTime = 0.0f;
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
            SwapSkill(0);
        }
        else if (Input.GetKey("2"))
        {
            SwapSkill(1);
        }
        else if (Input.GetKey("3"))
        {
            SwapSkill(2);
        }

        if (Time.time > nextActionTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                nextActionTime = Time.time + currentSkill.cooldown;
                if (currentSkill != null)
                {
                    Debug.Log("Player attacked using " + currentSkill.name);
                    GameObject newBullet = (GameObject)Instantiate(currentSkill.skillBullet, attackPos.position, attackPos.rotation);
                    Destroy(newBullet, 2f);

                }


            }
        }
    }

    public void SwapSkill(int i)
    {
        currentSkill = skillList[i];
    }

    public void AddSkill(Skills skill)
    {
        if (skillList.Count != slots)
        {
            skillList.Add(skill);
            UpdateSkillUI();
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
