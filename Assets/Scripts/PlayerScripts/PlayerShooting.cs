using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;  // The projectile prefab to be instantiated
    public float projectileSpeed = 10f;  // Speed of the projectile
    public float projectileLifeTime = 3f; //LifeTime of the projectile
    public float firerate = 0.2f;
    public float nextShotTime;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextShotTime) // Right mouse button
        {
            ShootProjectile();
            nextShotTime = Time.time + 1f / firerate;
        }
    }

    void ShootProjectile()
    {

        // Get the mouse position in the world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);

        // Calculate the direction from the enemy (player's position) to the mouse position
        Vector3 direction = (mousePosition - transform.position).normalized;
        direction.Normalize();

        // Instantiate the projectile at the player's position
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Get the projectile's Rigidbody2D component and set its velocity
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.velocity = direction * projectileSpeed;


        Destroy(projectile, projectileLifeTime);
    }

}