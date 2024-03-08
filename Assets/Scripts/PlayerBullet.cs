using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float projectileSpeed = 10f;  // Speed of the projectile
    public int damage = 10;              // Damage dealt to enemies
    public float lifetime = 3f;          // Lifetime of the projectile
    
    // Cached references
    Rigidbody2D myRigidbody;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();  
    }

    void Start()
    {
        // Set the projectile's lifetime
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.right = myRigidbody.velocity;
    }

    void FixedUpdate()
    {
        // Move the projectile forward
       //rb.transform.position += Vector3.right * projectileSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        // Check if the collided object has the "Enemy" tag
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Deal damage to the enemy
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

            // Destroy the projectile on collision with an enemy
            Destroy(gameObject);
        }
    }
}
