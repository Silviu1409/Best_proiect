using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    Vector3 targetOffset;           //distance offset from target to camera

    [SerializeField]
    [Range(2f, 5f)]
    float movementSpeed = 5f;       //camera movement speed

    [SerializeField]
    [Range(10f, 30f)]
    float minFOV = 25f;             //max zoom in

    [SerializeField]
    [Range(70f, 90f)]
    float maxFOV = 75f;             //max zoom out

    [SerializeField]
    float zoomSensitivity = 10f;    //scroll sensitivity for zooming

    void Update()
    {
        MoveCamera();
        HandleZoomInOut();
    }

    //Camera movement
    void MoveCamera()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + targetOffset, movementSpeed * Time.deltaTime);
    }

    //Zoom in and out
    void HandleZoomInOut()
    {
        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;
        fov = Mathf.Clamp(fov, minFOV, maxFOV);
        Camera.main.fieldOfView = fov;
    }
}
