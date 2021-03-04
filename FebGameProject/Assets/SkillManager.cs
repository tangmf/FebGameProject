using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    public Transform attackPos;
    public List<Skills> skillList = new List<Skills>();
    public Skills currentSkill;
    // Start is called before the first frame update
    void Start()
    {
        if (Time.time > nextActionTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if(currentSkill != null)
                {
                    Debug.Log("Player attacked using " + currentSkill.name);
                    GameObject newBullet = (GameObject)Instantiate(currentSkill.skillBullet, attackPos.position, attackPos.rotation);
                    Destroy(newBullet, 2f);
                    nextActionTime += period;
                }


            }
        }
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
    }

    public void SwapSkill(int i)
    {
        currentSkill = skillList[i];
    }

    public void AddSkill(Skills skill)
    {
        skillList.Add(skill);
    }
}
