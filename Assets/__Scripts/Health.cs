using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth = 100;
    public bool isAlive;
    private Slider _scorebar;
    private float _health;
    private Slider _healthbar;
    private static float _score = 0;

    // Set player starting health
    void Awake()
    {
        isAlive = true;
        _health = maxHealth;
        _scorebar = GameObject.FindGameObjectWithTag("Score").GetComponent<Slider>();

        if (gameObject.tag == "Player")
        {
            _healthbar = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<Slider>();
        }

        if (gameObject.tag == "Enemy")
        {
            _healthbar = GetComponentInChildren<Slider>();
        }

        if(_healthbar != null)
        {
            _healthbar.maxValue = maxHealth;
            _healthbar.value = _health;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive && gameObject != null)
        {
            if (gameObject.tag == "Enemy")
            {
                _score += gameObject.GetComponent<BasicEnemy>().score;
                _scorebar.value = _score; 
            }

            Destroy(gameObject);
        }
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
            isAlive = false;
        }

        if (_healthbar != null)
        {
            _healthbar.value = _health;
        }
    }
}
