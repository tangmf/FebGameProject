using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    private float nextActionTime = 0.0f;
    public float period = 10f;
    public int startHour = 7;
    public Text hourText;
    // Start is called before the first frame update
    void Start()
    {
        hourText.text = startHour - 1 + ":00";
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            startHour++;
            if(startHour > 24)
            {
                startHour = 0;
            }
            else
            {
                hourText.text = startHour + ":00";
            }
            
        }
    }
}
