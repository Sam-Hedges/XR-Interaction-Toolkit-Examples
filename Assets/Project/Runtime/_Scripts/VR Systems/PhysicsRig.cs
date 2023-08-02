using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsRig : MonoBehaviour
{

    public Transform playerHead;
    public CapsuleCollider bodyCollider;
    
    public float bodyHeightMin = 1f;
    public float bodyHeightMax = 2f;
    
    
    void FixedUpdate()
    {
        var localPosition = playerHead.localPosition;
        bodyCollider.height = Mathf.Clamp(localPosition.y, bodyHeightMin, bodyHeightMax);
        bodyCollider.center = new Vector3(localPosition.x, bodyCollider.height / 2, localPosition.z);
    }
}
