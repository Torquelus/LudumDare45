using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineFreeLook))]//references to cinemachine

public class CameraRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
        }
        else
        {
            var freeLook = GetComponent<CinemachineFreeLook>();
            freeLook.m_XAxis.m_InputAxisName = "";
            freeLook.m_YAxis.m_InputAxisName = "";
        }
    }    
}
