using System;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
[Header("References")]
    [SerializeField] private Transform cameraHolder;
[SerializeField] private Transform orientation;

[Header("Look Settings")]
[SerializeField] private float sensX = 10f;
[SerializeField] private float sensY = 10f;

private float yRotation;
private float xRotation;

private void Start()
{
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
}

private void Update()
{

    // Only allow camera movement if the cursor is locked (i.e., menu is not open)
    if (Cursor.lockState != CursorLockMode.Locked)
        return;

    float mouseX = Input.GetAxisRaw("Mouse X") * 0.1f;
    float mouseY = Input.GetAxisRaw("Mouse Y") * 0.1f;

    yRotation += mouseX * sensX;
    xRotation -= mouseY * sensY;

    xRotation = Mathf.Clamp(xRotation, -90f, 90f);

    orientation.rotation = Quaternion.Euler(0f, yRotation, 0f);
    cameraHolder.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

}

}