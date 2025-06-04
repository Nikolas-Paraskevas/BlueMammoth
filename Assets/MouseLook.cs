using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    float yRotation = 0f; // Vertical rotation (up/down)
    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (playerBody == null)
        {
            Debug.LogError("PlayerBody not assigned in MouseLook script!");
        }
    }

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Calculate vertical rotation and clamp it
        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        //xRotation += mouseX;
        //xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Rotate the camera up and down (pitch)
        transform.localRotation = Quaternion.Euler(yRotation, 0, 0f);
        //transform.localRotation = Quaternion.Euler(0, xRotation, 0f);

        // Rotate the player left and right (yaw)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
