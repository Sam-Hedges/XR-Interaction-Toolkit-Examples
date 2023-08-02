using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickVR : MonoBehaviour
{

    [SerializeField] private Transform topOfJoystick;
    [SerializeField] private float uTilt;
    [SerializeField] private float vTilt;


    void Update()
    {

        vTilt = topOfJoystick.rotation.eulerAngles.x;

        if (vTilt is < 355 and > 290)
        {
            vTilt = Math.Abs(vTilt - 360);
        }
        
        uTilt = topOfJoystick.rotation.eulerAngles.z;
        
        if (uTilt is < 355 and > 290)
        {
            uTilt = Math.Abs(uTilt - 360);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            transform.LookAt(other.transform.position, transform.up);
        }
    }
}
