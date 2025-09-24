using System;
using UnityEngine;


public class EnemyStats : StatManager
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] private int experience;
    [SerializeField] private float damageInterval = 1f;
    private float _lastDamageTime;

    public void Update()
    {

    }

    protected override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        

    }

    protected void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player") && Time.time > _lastDamageTime + damageInterval)
        {
            playerStats.ReceivedDamage(damage);
            _lastDamageTime = Time.time;
            
        }
    }

    protected override void Die()
    {
        playerStats.GainExperience(experience);

    }
}
