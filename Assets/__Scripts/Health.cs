using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth = 100;
    public bool isAlive;
    public Text scoreText;
    private float _health;
    private Slider _healthbar;
    private static float _score = 0;

    // Set player starting health
    void Awake()
    {
        isAlive = true;
        _health = maxHealth;
        _healthbar = GetComponentInChildren<Slider>();
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();

        if(_healthbar != null)
        {
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
                scoreText.text = "Score: " + _score;
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
