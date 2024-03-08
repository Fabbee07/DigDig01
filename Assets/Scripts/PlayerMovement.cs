using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Configurable parameters
    [SerializeField] float moveSpeed = 5.0f; // Speed at which the object moves

    // Private variables
    Vector2 movementInput;
    Vector2 runVelocity;
    bool playerHasSpeed;

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
    public float moveSpeed = 5f; // Speed at which the object moves
    public Rigidbody2D rb = null;

    private Vector3 currentPosition;

    void Update()
    {
        // Get input from arrow keys (or WASD keys)
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;

        // Get the current position of the player
      
        Vector3 currentPosition = rb.position;
        currentPosition = rb.position;
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
       rb.position = newPosition;
    }

    void FixedUpdate()
    {
        Movement();
    }

    void CheckInput()
    {
        // Get input from arrow keys (or WASD keys)
        movementInput.x = Input.GetAxisRaw("Horizontal"); // Can be changed to GetAxisRaw for snappier movement
        movementInput.y = Input.GetAxisRaw("Vertical");
    }


    void Movement()
    {
        // This makes the player move 
        runVelocity = new Vector2(movementInput.x * moveSpeed, movementInput.y * moveSpeed);
        myRigidbody.velocity = runVelocity;

        // This plays the movement animation
        if (Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon || Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon) 
        { 
            playerHasSpeed = true;
        }
        else
        {
            playerHasSpeed = false;
        }

        myAnimator.SetBool("isWalking", playerHasSpeed);


    }
}