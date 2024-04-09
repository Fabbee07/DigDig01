using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public int health;
    public GameObject[] hearts;
    public string GameOverScene;

    private bool dead;

    // Update is called once per frame

    void Update()
    {
        if(health <= 0)
        {
            SceneManager.LoadScene(GameOverScene);
        }

        if (health < 1)
        {
            hearts[0].gameObject.SetActive(false);
        }

        else if (health < 2)
        {
            hearts[1].gameObject.SetActive(false);
        }
        else if (health < 3)
        {
            hearts[2].gameObject.SetActive(false);
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
            hearts[0].gameObject.SetActive(false);

            // TODO add death animation, maybe sounds and effects?
            Destroy(gameObject);

            SceneManager.LoadScene(GameOverScene);


        }
    }
}