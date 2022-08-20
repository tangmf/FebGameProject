using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dispenser : MonoBehaviour
{
    public Item item;
    public GameObject value;
    public GameObject display;
    public int count = 30;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        display.GetComponent<SpriteRenderer>().sprite = item.itemSprite;
        UpdateValue();

    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Player" && Input.GetKeyDown("e"))
        {
            if(count > 0)
            {
                Instantiate(item.droppedItem, spawnPoint.position, spawnPoint.rotation);
                count--;
                UpdateValue();
            }
            
        }

    }
    public void UpdateValue()
    {
        value.GetComponent<TextMesh>().text = count.ToString();
    }
}
