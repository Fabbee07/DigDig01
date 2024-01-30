using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the object moves

    void Update()
    {
        // Get input from arrow keys (or WASD keys)
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;

        // Get the current position of the player
        Vector3 currentPosition = transform.position;

        // Calculate the position after movement
        Vector3 newPosition = currentPosition + movement;

        // Get the viewport position of the calculated position
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(newPosition);

        // Restrict the player's position within the camera's viewport
        viewportPosition.x = Mathf.Clamp01(viewportPosition.x);
        viewportPosition.y = Mathf.Clamp01(viewportPosition.y);

        // Convert the clamped viewport position back to world space
        newPosition = Camera.main.ViewportToWorldPoint(viewportPosition);

        // Apply the movement within the camera bounds
        transform.position = newPosition;
    }
}
