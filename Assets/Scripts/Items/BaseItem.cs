using System;
using UnityEngine;

public abstract class BaseItem : MonoBehaviour
{
    protected abstract void OnItemEvent(PlayerStats playerStats);
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            OnItemEvent(playerStats);
            
            Destroy(gameObject);
        }
    }
}