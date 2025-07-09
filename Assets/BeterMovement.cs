using System;
using UnityEngine;

public class BeterMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform orientation;

    [Header("Movement")]
    [SerializeField] private float speed = 40f;

    [Header("Jump")]
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float groundCheckDistance = 0.2f;
    [SerializeField] private LayerMask groundMask;

    [Header("Drag")]
    [SerializeField] private float drag = 6f;

    private Vector3 moveDirection;
    private float horizontalInput;
    private float verticalInput;
    private bool isGrounded;

    private void Start() => rb.freezeRotation = true;

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        moveDirection = (orientation.forward * verticalInput + orientation.right * horizontalInput).normalized;

        rb.drag = drag;

        // Improved ground check
        isGrounded = Physics.SphereCast(transform.position, 0.3f, Vector3.down, out _, groundCheckDistance, groundMask);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
        Debug.Log("isGrounded: " + isGrounded);
    }


    private void FixedUpdate()
    {
        rb.AddForce(moveDirection * speed, ForceMode.Acceleration);
    }

    private void Jump()
    {
        // Reset vertical velocity before jumping for consistent jumps
        Vector3 velocity = rb.velocity;
        velocity.y = 0f;
        rb.velocity = velocity;

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
