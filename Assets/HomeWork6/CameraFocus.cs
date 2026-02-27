using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Actions;

public class CameraFocus : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 120f;
    [SerializeField] private float distance = 5f;

    private Vector2 Rotation;
    private Vector3 CameraRotate;

    private float xRotation;
    private float yRotation;
    [SerializeField] private float minVerticalAngle = -40f;
    [SerializeField] private float maxVerticalAngle = 70f;

    [SerializeField] InputAction hoirzontalAxis;
    [SerializeField] InputAction verticalAxis;

    [SerializeField] Transform Transform;


    private void OnEnable()
    {
        hoirzontalAxis.Enable();
        verticalAxis.Enable();
    }
    private void OnDisable()
    {
        hoirzontalAxis.Disable();
        verticalAxis.Disable();
    }
    void LateUpdate()
    {
        RotateCamera();
    }
    private void Update()
    {
        transform.position = Transform.position;
        Transform.rotation = Quaternion.Euler(0, yRotation, 0f);
        Rotation.x = hoirzontalAxis.ReadValue<float>();
        Rotation.y = verticalAxis.ReadValue<float>();
    }
    void RotateCamera()
    {

        yRotation += Rotation.x * mouseSensitivity * Time.deltaTime;
        xRotation -= Rotation.y * mouseSensitivity * Time.deltaTime;

        xRotation = Mathf.Clamp(xRotation, minVerticalAngle, maxVerticalAngle);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }

}