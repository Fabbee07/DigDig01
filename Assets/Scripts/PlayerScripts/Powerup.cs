using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public HealthBuff powerupEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
            PlayerHealth playerHealth = null;
            if (collision.CompareTag("player"))
            {
                playerHealth = collision.GetComponent<PlayerHealth>();
            }

            if (playerHealth != null)
            {
                if (!playerHealth.IsAtMaxHealth())
                {
                    playerHealth.AddHearts(powerupEffect.heartsToAdd);
                }
            }
        
        Destroy(gameObject);  
        powerupEffect.Apply(collision.gameObject);
    }
}
