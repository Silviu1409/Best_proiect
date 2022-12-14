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
    [Range(25f, 35f)]
    float minFOV = 30f;             //max zoom in

    [SerializeField]
    [Range(55f, 65f)]
    float maxFOV = 60f;             //max zoom out

    [SerializeField]
    float zoomSensitivity = 10f;    //scroll sensitivity for zooming

    void Update()
    {
        MoveCamera();
        HandleZoomInOut();
    }

    // Camera movement
    void MoveCamera()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + targetOffset, movementSpeed * Time.deltaTime);
    }

    // Zoom in and out
    void HandleZoomInOut()
    {
        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSensitivity;   //Mouse scrollwheel is inverted, so we have to multiply it with -1
        fov = Mathf.Clamp(fov, minFOV, maxFOV);
        Camera.main.fieldOfView = fov;
    }
}
