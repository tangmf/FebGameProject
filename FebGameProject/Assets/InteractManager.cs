using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractManager : MonoBehaviour
{
    public Image icon;
    public GameObject interactManagerObject;
    // Start is called before the first frame update
    void Start()
    {
        //SetIcon(image);
        interactManagerObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    public void ToggleOn()
    {
        interactManagerObject.SetActive(true);
    }

    public void ToggleOff()
    {
        interactManagerObject.SetActive(false);
    }
}
