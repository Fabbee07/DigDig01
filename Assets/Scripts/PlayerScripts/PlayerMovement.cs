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
        float movementDir = myRigidbody.velocity.x;
        movementDir = Mathf.Sign(movementDir);
        Vector3 playerScale = gameObject.transform.localScale;
        playerScale.x = movementDir;
        gameObject.transform.localScale = playerScale;


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
