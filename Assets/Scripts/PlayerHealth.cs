using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 1;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            currentHealth -= 1;
            Debug.Log("-1 health");
        }
    }
}
