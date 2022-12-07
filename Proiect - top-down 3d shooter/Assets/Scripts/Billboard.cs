using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform CameraTransform;
    void LateUpdate()
    {
        transform.LookAt(transform.position + CameraTransform.forward);
    }
}
