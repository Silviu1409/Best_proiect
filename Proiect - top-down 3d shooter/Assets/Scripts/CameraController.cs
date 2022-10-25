using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    Vector3 targetOffset;

    [Range(2f, 5f)]
    public float movementSpeed = 5f;

    float minFOV = 25f;
    float maxFOV = 75f;
    float sensitivity = 10f;

    void Start()
    {
        
    }

    void Update()
    {
        MoveCamera();
        HandleZoomInOut();
    }

    void MoveCamera()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + targetOffset, movementSpeed * Time.deltaTime);
    }

    void HandleZoomInOut()
    {
        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFOV, maxFOV);
        Camera.main.fieldOfView = fov;

    }
}
