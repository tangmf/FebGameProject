using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

[CreateAssetMenu(fileName = "New Item", menuName = "Items")]
public class Item : ScriptableObject
{
    public new string name;
    public string desc;
    public int damage;
    public int defence;
    public Sprite itemSprite;
    public GameObject droppedItem;
    public GameObject bullet;
    public AnimatorController animator;
}
