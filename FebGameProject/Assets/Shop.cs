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
    public List<GameObject> playersInCollision = new List<GameObject>();

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

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Player" && Input.GetKeyDown("e"))
        {
            playersInCollision.Add(collider.gameObject);
            ToggleUI();
        }
        
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            playersInCollision.Remove(collider.gameObject);
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

    public void Buy()
    {
        Debug.Log("Skill bought");
        foreach(GameObject player in playersInCollision)
        {
            player.GetComponent<SkillManager>().AddSkill(skillOnSale);
        }
    }

}
