using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Configurable parameters
    [SerializeField] float moveSpeed = 5f; // Speed at which the object moves

    // Private variables
    float horizontalInput;
    float verticalInput;
    Vector3 newPosition;

    // Cached references
    Rigidbody2D myRigidbody;
    Animator myAnimator;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        CheckInput();
    }

    void FixedUpdate()
    {
        Movement();
    }

    void CheckInput()
    {
        // Get input from arrow keys (or WASD keys)
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    void Movement()
    {
        // Calculate the movement direction
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed;

        // Get the current position of the player
        Vector3 currentPosition = myRigidbody.position;

        // Calculate the position after movement
        newPosition = currentPosition + movement;

        // Get the viewport position of the calculated position
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(newPosition);

        // Restrict the player's position within the camera's viewport
        viewportPosition.x = Mathf.Clamp01(viewportPosition.x);
        viewportPosition.y = Mathf.Clamp01(viewportPosition.y);

        // Convert the clamped viewport position back to world space
        newPosition = Camera.main.ViewportToWorldPoint(viewportPosition);

        // Apply the movement within the camera bounds
        myRigidbody.position = newPosition;
    }
}