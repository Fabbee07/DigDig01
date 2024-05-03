using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Speed of the bullet
    public int damage = 1; // Damage inflicted by the bullet

    void Update()
    {
        // Move the bullet forward
        transform.Translate(Vector2.up * speed * Time.deltaTime, Space.Self);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the bullet collided with an object tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Inflict damage to the player
            other.GetComponent<PlayerHealth>().TakeDamage(damage);

            // Destroy the bullet on collision with the player
            Destroy(gameObject);
        }
        else if (other.CompareTag("Obstacle"))
        {
            // Destroy the bullet on collision with an obstacle
            Destroy(gameObject);
        }
    }
}
