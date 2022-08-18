using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Zoom : MonoBehaviour
{
    public float defaultValue = 1.0f;
    public float min = 0.5f;
    public float max = 5.0f;
    private CinemachineVirtualCamera vcam;
    // Start is called before the first frame update
    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ZoomOut(float x)
    {
        vcam.m_Lens.OrthographicSize += x;
        if(vcam.m_Lens.OrthographicSize>= max)
        {
            vcam.m_Lens.OrthographicSize = max;
        }
    }

    public void ZoomIn(float x)
    {
        vcam.m_Lens.OrthographicSize -= x;
        if (vcam.m_Lens.OrthographicSize <= min)
        {
            vcam.m_Lens.OrthographicSize = min;
        }
    }

    public void ZoomReset()
    {
        vcam.m_Lens.OrthographicSize = defaultValue;
    }
}
