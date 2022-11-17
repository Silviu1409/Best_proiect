using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform target;               //targetul camerei

    [SerializeField]
    Vector3 targetOffset;           //distanta de la target la camera

    [SerializeField]
    [Range(2f, 5f)]
    float movementSpeed = 5f;       //viteza cu care camera se va deplasa

    [SerializeField]
    [Range(10f, 30f)]
    float minFOV = 25f;             //FOV-ul minim al camerei(Zoom in maxim)

    [SerializeField]
    [Range(70f, 90f)]
    float maxFOV = 75f;             //FOV-ul maxim al camerei(Zoom out maxim)

    [SerializeField]
    float zoomSensitivity = 10f;    //sensitivitatea la scroll pentru zoom in/out

    void Update()
    {
        MoveCamera();
        HandleZoomInOut();
    }

    //functia de deplasare a camerei in functie de target
    void MoveCamera()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + targetOffset, movementSpeed * Time.deltaTime);
    }

    //functia ce se ocupa de zoom in si zoom out la mouse scroll
    void HandleZoomInOut()
    {
        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;
        fov = Mathf.Clamp(fov, minFOV, maxFOV);
        Camera.main.fieldOfView = fov;
    }
}
