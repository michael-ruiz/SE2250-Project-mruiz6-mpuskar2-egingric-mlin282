using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    private float _health;

    // Set player starting health
    void Awake()
    {
        _health = maxHealth;
    }

    // Increase or decrease health by a given value
    public void UpdateHealth(float change)
    {
        _health += change;

        if (_health > maxHealth)
        {
            _health = maxHealth;
        }

        else if (_health <= 0)
        {
            _health = 0;
            // Player dead, restart?
        }
    }
}
