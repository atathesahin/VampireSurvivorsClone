using System;
using UnityEngine;


public class EnemyStats : StatManager
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] private int experience;

    public void Update()
    {
    

    }

    protected override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        

    }

    protected override void Die()
    {
        base.Die();
        currentExperience += experience;


    }
}
