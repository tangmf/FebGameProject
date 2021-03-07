using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject ShopUI;
    public Skills skillOnSale;
    public Image Icon;
    public Text Name;
    // Start is called before the first frame update
    void Start()
    {
        Icon.sprite = skillOnSale.skillIcon;
        Name.text = skillOnSale.name;
        ShopUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && Input.GetKeyDown("e"))
        {
            ToggleUI();
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            ShopUI.SetActive(false);
        }

    }

    void ToggleUI()
    {
        if (ShopUI.activeSelf)
        {
            ShopUI.SetActive(false);
        }
        else
        {
            ShopUI.SetActive(true);
        }
    }


}
