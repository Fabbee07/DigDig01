using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    public int health;
    public GameObject[] hearts;

    public Sprite fullHeart;
    public Sprite emptyHeart;
    private bool dead;

    private void Start()
    {
        health = hearts.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 1)
        {
            Destroy(hearts[0].gameObject);
        }

        else if (health < 2)
        {
            Destroy(hearts[1].gameObject);
        }
        else if (health < 3)
        {
            Destroy(hearts[2].gameObject);
        }
        {
            if (dead == true)
            {
                Debug.Log("YOU DEDDDD!!!");
            }
        }
    }

    public void TakeDamage(int d)
    {
        health -= d;
        if (health <= 0)
        {
            dead = true;
            Destroy(gameObject);
            Destroy(hearts[0].gameObject);

        }
    }
}