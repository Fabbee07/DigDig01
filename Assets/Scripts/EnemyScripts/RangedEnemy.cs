using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public Transform player; // Player's transform
    public float moveSpeed = 3f; // Movement speed of the enemy
    public float BulletSpeed = 10.0f;
    public float shootingRange = 5f; // Radius within which the enemy can shoot the player
    public float shootInterval = 2f; // Time interval between shots
    public GameObject bulletPrefab; // Prefab of the bullet

    private float shootTimer; // Timer to control shooting intervals

    void Update()
    {
        // Check if the player is within shooting range
        if (Vector2.Distance(transform.position, player.position) <= shootingRange)
        {         

            // Shoot at the player
            Shoot();
        }
        else
        {
            // Move towards the player if outside shooting range
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }

    void Shoot()
    {
        // Increment shoot timer
        shootTimer += Time.deltaTime;

        // Check if enough time has passed to shoot again
        if (shootTimer >= shootInterval)
        {
            // Reset shoot timer
            shootTimer = 0f;

            // Instantiate bullet
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            // Set bullet direction towards the player
            bullet.GetComponent<Rigidbody2D>().velocity = (player.transform.position - transform.position).normalized * BulletSpeed;
        }
    }
}
