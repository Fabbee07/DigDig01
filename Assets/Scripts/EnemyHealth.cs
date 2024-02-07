using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;  // Maximum health of the enemy
    private int currentHealth;    // Current health of the enemy

    void Start()
    {
        // Initialize current health to max health when the enemy is spawned
        currentHealth = maxHealth;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object has the "bullet" tag
        if (other.CompareTag("bullet"))
        {
            // Reduce the enemy's health by the damage of the bullet
            PlayerBullet bullet = other.GetComponent<PlayerBullet>();
            if (bullet != null)
            {
                TakeDamage(bullet.damage);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        // Reduce the enemy's health by the given damage amount
        currentHealth -= damage;

        // Check if the enemy has been defeated
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Perform any death-related actions here, e.g., play death animation, spawn particles, etc.

        // Destroy the enemy GameObject
        Destroy(gameObject);
    }
}
