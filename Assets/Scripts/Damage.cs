using UnityEngine;

public class Damage : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage = 1;
    //public GameObject[] hearts;
    private int health;

    public int Health { get => health; set => health = value; }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("damage");
            playerHealth.TakeDamage(damage);
        }
    }
}

