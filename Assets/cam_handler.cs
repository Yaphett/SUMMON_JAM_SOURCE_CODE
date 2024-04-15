using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_handler : MonoBehaviour
{
    public float zoomSpeed = 5f; // Zoom speed adjustment.
    public float smoothness = 5f; // Smoothness of zooming.
    public float minZoom = 2f;   // Minimum zoom level.
    public float maxZoom = 10f;  // Maximum zoom level.
    public Vector2 zoomBoundsX = new Vector2(-10f, 10f); // X-axis zoom bounds.
    public Vector2 zoomBoundsY = new Vector2(-10f, 10f); // Y-axis zoom bounds.
    public float dragSpeed = 1f; // Drag speed adjustment.

    public Vector3 dragVelocity; // Velocity of camera movement after drag
    public float dragVelocityMultiplier = 10f; // Multiplier for initial drag velocity
    public float dampingFactor = 0.98f; // Damping factor for drag velocity

    private Camera mainCamera;
    private Vector3 dragOrigin;

    private float targetZoom; // Target zoom level.

    private void Start()
    {
        // Get the main Camera component.
        mainCamera = Camera.main;
        targetZoom = mainCamera.orthographicSize;
    }

    private void Update()
    {
        HandleZoom();
        HandleDrag();
    }

    private void HandleZoom()
    {
        // Get the mouse scroll wheel input.
        float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");

        // Calculate the target zoom level.
        targetZoom -= scrollWheelInput * zoomSpeed;
        targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);

        // Smoothly adjust the current zoom level towards the target over time.
        mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, targetZoom, Time.deltaTime * smoothness);

        // Clamp the camera's position within the specified bounds.
        Vector3 newPosition = mainCamera.transform.position;
        newPosition.x = Mathf.Clamp(newPosition.x, zoomBoundsX.x, zoomBoundsX.y);
        newPosition.y = Mathf.Clamp(newPosition.y, zoomBoundsY.x, zoomBoundsY.y);
        mainCamera.transform.position = newPosition;
    }

    private void HandleDrag()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            dragVelocity = Vector3.zero; // Reset drag velocity
        }

        if (Input.GetMouseButton(0))
        {
            // Calculate the target position based on drag speed and smoothness.
            Vector3 targetPosition = mainCamera.transform.position;

            // Calculate the difference between the current position and the drag origin.
            Vector3 difference = dragOrigin - mainCamera.ScreenToWorldPoint(Input.mousePosition);

            // Update the target position based on the drag difference.
            targetPosition += difference * dragSpeed;

            // Smoothly adjust the current position towards the target over time.
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition, Time.deltaTime * smoothness);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // Calculate drag velocity based on the difference between current and previous mouse position
            Vector3 currentMousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 dragDirection = (currentMousePos - dragOrigin).normalized; // Flip direction
            dragVelocity = dragDirection * Mathf.Clamp(Vector3.Distance(currentMousePos, dragOrigin), 0f, 1f) * dragSpeed * dragVelocityMultiplier;
        }

        // Apply drag velocity after mouse is released
        mainCamera.transform.position += dragVelocity * Time.deltaTime;

        // Dampen drag velocity over time
        dragVelocity *= dampingFactor;
    }
}