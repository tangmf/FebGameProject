using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Skill")]
public class Skills : ScriptableObject
{
    public new string name;
    public string desc;
    public Sprite skillIcon;
    public GameObject skillBullet;
}
