using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed of the character
    public float smoothingFactor = 0.1f; // Smoothing factor for velocity adjustment

    private Rigidbody2D rb;
    private Vector2 moveInput;

    private void Start()
    {
        // Get the Rigidbody2D component attached to the character
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get horizontal and vertical input (arrow keys, WASD keys, or joystick)
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Store the input values
        moveInput = new Vector2(horizontalInput, verticalInput).normalized;
    }

    private void FixedUpdate()
    {
        // Move the character
        MoveCharacter(moveInput);
    }

    private void MoveCharacter(Vector2 inputDirection)
    {
        // Calculate the target velocity based on input direction and speed
        Vector2 targetVelocity = inputDirection * moveSpeed;

        // Smooth out the velocity change to prevent sliding
        rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, smoothingFactor);
    }
}
