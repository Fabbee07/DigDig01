using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float projectileSpeed = 10f;  // Speed of the projectile
    public int damage = 10;              // Damage dealt to enemies
    public float lifetime = 3f;          // Lifetime of the projectile
    

    GameObject EnemyHealth;

    void Start()
    {
        // Set the projectile's lifetime
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Move the projectile forward
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object has the "Enemy" tag
        if (other.CompareTag("Enemy"))
        {
            // Deal damage to the enemy
            EnemyHealth enemyHealth = other.GetComponent<enemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

            // Destroy the projectile on collision with an enemy
            Destroy(gameObject);
        }
    }
}
