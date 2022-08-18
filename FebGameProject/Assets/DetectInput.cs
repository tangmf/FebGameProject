using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectInput : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject camera;
    public float scrollRate = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (PauseMenu.activeSelf)
            {
                PauseMenu.SetActive(false);
                Debug.Log("Menu closed");
                Time.timeScale = 1.0f;
            }
            else
            {
                PauseMenu.SetActive(true);
                Debug.Log("Menu opened");
                Time.timeScale = 0.0f;
            }


        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            camera.GetComponent<Zoom>().ZoomIn(scrollRate);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            camera.GetComponent<Zoom>().ZoomOut(scrollRate);
        }
    }

}
