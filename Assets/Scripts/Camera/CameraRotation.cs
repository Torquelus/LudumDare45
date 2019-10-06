using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineFreeLook))]//references to cinemachine

public class CameraRotation : MonoBehaviour
{
    private float Xrotation, Yrotation; //stores the rotation last left at

    // Start is called before the first frame update
    void Start()
    {
        Xrotation = 0;
        Yrotation = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(2)) {  //0 = left click, 1 = right click, 2 is middle
            //true if right mouse button is being held

            //gets
            var freeLook = GetComponent<CinemachineFreeLook>();
            freeLook.m_XAxis.m_InputAxisName = "Mouse X";
            freeLook.m_YAxis.m_InputAxisName = "Mouse Y";
            Xrotation = freeLook.m_XAxis.Value;
            Yrotation = freeLook.m_YAxis.Value;
        }
        else
        {
            var freeLook = GetComponent<CinemachineFreeLook>();
            freeLook.m_XAxis.m_InputAxisName = "";  
            freeLook.m_YAxis.m_InputAxisName = "";

            freeLook.m_XAxis.Value = Xrotation;
            freeLook.m_YAxis.Value = Yrotation;

        }
    }    
}
