using UnityEngine;

public class DamageDealer : MonoBehaviour
{

    public int damage = 1;
    //public GameObject[] hearts;
    private int health;

    public int Health { get => health; set => health = value; }

    // Cached references
    PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("damage");
            playerHealth.TakeDamage(damage);
        }
    }
}

