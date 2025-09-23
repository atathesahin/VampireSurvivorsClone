using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : BaseItem
{
    [SerializeField] private int health;

    protected override void OnItemEvent(PlayerStats playerStats)
    {
        playerStats.CurrentHealth += health;
    }
}
