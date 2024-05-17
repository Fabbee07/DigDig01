using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float meleeRange = 5f; // The range within which the boss switches to melee
    public float attackCooldown = 1f; // Cooldown time between attacks

    private float lastAttackTime;

    void Update()
    {
        // Calculate the distance to the player
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Check if the boss can attack
        if (Time.time > lastAttackTime + attackCooldown)
        {
            if (distanceToPlayer <= meleeRange)
            {
                MeleeAttack();
            }
            else
            {
                RangedAttack();
            }

            lastAttackTime = Time.time;
        }
    }

    void RangedAttack()
    {
        // Implement the ranged attack logic here
        Debug.Log("Ranged Attack");
    }

    void MeleeAttack()
    {
        // Implement the melee attack logic here
        Debug.Log("Melee Attack");
    }
}