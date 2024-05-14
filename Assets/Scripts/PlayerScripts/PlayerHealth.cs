using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    Animator myAnimator;

    public int maxHealth = 3;
    private int currentHealth = 3;

    public int health;
    public GameObject[] hearts;
    public string GameOverScene;
    private bool dead;

    private void Awake()
    {
        myAnimator = GetComponentInChildren<Animator>();
    }

    public bool IsAtMaxHealth()
    {
        return currentHealth >= maxHealth;
    }

    public void AddHearts(int heartsToadd)
    {
        currentHealth = heartsToadd;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
    }


    void Update()
    {
    }

    public void TakeDamage(int d)
    {
        health -= d;


        if (health < 1)
        {
            hearts[0].SetActive(false);
        }

        else if (health < 2)
        {
            hearts[1].SetActive(false);
        }
        else if (health < 3)
        {
            hearts[2].SetActive(false);
        }


        if (health <= 0)
        {
            dead = true;
            //Destroy(gameObject);
            hearts[0].SetActive(false);

            PlayerMovement hej = GetComponent<PlayerMovement>();
            hej.isDead = true;

            myAnimator.SetTrigger("IsDead");

            StartCoroutine("PlayerDies");

        }
    }

    IEnumerator PlayerDies()
    {
        Debug.Log("This happens! first");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(GameOverScene);
    }
}