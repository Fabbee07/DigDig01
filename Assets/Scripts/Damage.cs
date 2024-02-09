using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Health playerHealth;
    public int damage = 2;
    public GameObject[] hearts;
    private int health;

    public int Health { get => health; set => health = value; }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}