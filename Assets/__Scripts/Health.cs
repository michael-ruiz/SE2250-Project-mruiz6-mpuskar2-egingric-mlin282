using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth = 100;
    private float _health;
    private Slider _healthbar;

    // Set player starting health
    void Awake()
    {
        _health = maxHealth;
        _healthbar = GetComponentInChildren<Slider>();
        _healthbar.value = _health;
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

        _healthbar.value = _health;
    }

    public float health
    {
        get { return _health; }
        set { _health = value; }
    }
}
