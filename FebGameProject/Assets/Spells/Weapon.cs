using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject firespell;
    public GameObject icespell;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot("fire");
        } else if (Input.GetButtonDown("Fire2"))
        {
            Shoot("ice");
        }
    }

    void Shoot(string spellname)
    {
        switch (spellname) {
            case "fire": Instantiate(firespell, firepoint.position, firepoint.rotation);
            break;

            case "ice": Instantiate(icespell, firepoint.position, firepoint.rotation);
            break;
        }
    }
}
