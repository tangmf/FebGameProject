using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Item", menuName = "Items")]
public class Item : ScriptableObject
{
    public string type;
    public new string name;
    public string desc;
    public int damage;
    public int defence;
    public int maxStack;
    public Sprite itemSprite;
    public GameObject droppedItem;
    public GameObject bullet;
    public GameObject tileObject;
}
