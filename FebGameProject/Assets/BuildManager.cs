using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public GameObject tilePainter;

    // Start is called before the first frame update
    void Start()
    {
        playerInventory = GetComponent<PlayerInventory>();
        tilePainter.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate(Item item)
    {
        tilePainter.SetActive(true);
        tilePainter.GetComponent<TilePainter>().AssignItem(item);
    }

    public void DeActivate()
    {
        Debug.Log("Building disabled");
        tilePainter.GetComponent<TilePainter>().AssignItem(null);
        tilePainter.SetActive(false);
        
    }

    public void TilePainted()
    {
        playerInventory.UseCurrentItem();
    }
}
