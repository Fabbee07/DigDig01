using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/HealthBuff")]
public class HealthBuff : PowerupEffect
{
    public int heartsToAdd = 1;

    public int amount = 1;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerHealth>().health += amount;
    }
}