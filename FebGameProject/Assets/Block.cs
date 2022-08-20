using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Item item;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BreakBlock()
    {
        if (item.canBreak)
        {
            Destroy(gameObject);
            Instantiate(item.droppedItem, transform.position, transform.rotation);
        }
    }

}
