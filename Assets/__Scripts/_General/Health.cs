using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth = 100;
    public bool isAlive;
    public GameObject healthDrop;
    private Slider _scorebar;
    private float _health;
    private Slider _healthbar;
    public static float score = 0;
    public static float maxScore = 200;

    // Regen variables
    private float _timeSinceLastHit = 0;
    private float _regenTimer = 5;
    private float _regenQuanity = 5;

    // Set player starting health
    void Awake()
    {
        isAlive = true;
        _health = maxHealth;
        _scorebar = GameObject.FindGameObjectWithTag("Score").GetComponent<Slider>();

        if (gameObject.CompareTag("Player"))
        {
            _healthbar = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<Slider>();
        }

        if (gameObject.CompareTag("Enemy"))
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
            if (gameObject.CompareTag("Enemy"))
            {
                int dropHealth = Random.Range(0, 20);
                score += gameObject.GetComponent<BasicEnemy>().score;
                _scorebar.value = score;

                if (gameObject.GetComponent<DropBomb>() != null)
                {
                    gameObject.GetComponent<DropBomb>().EnemyDropBomb();
                }

                if (dropHealth == 0)
                {
                    GameObject pickup = Instantiate(healthDrop);
                    pickup.transform.position = transform.position;
                }
            }

            if (gameObject.CompareTag("Player"))
            {
                DeathMenu.OpenDeathMenu();
                score = 0;

                // Reset damage multipliers on death
                gameObject.GetComponent<MeleeAttack>().damage = gameObject.GetComponent<MeleeAttack>().baseDamage;
                Projectile.damageMultiplier = 1;
                Bomb.damageMultiplier = 1;
            }

            Destroy(gameObject);
        }

        Regen();
    }

    // Increase or decrease health by a given value
    public void UpdateHealth(float change)
    {
        _timeSinceLastHit = 0;

        if (GetComponent<Char1Movement>() == null)
        {
            _health += change;
        }
        else
        {
            if (Input.GetKey(KeyCode.E)) // If it's character 1 and they are holding E, reduce damage taken
            {
                _health += (change * 0.25f);
            }
            else
            {
                _health += change;
            }
        }

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

    private void Regen()
    {
        if (gameObject.CompareTag("Player"))
        {
            if (_timeSinceLastHit > _regenTimer)
            {
                UpdateHealth(_regenQuanity);
            }
            else
            {
                _timeSinceLastHit += Time.deltaTime;
            }
        }
    }

    public void IncreaseMaxHealth()
    {
        maxHealth *= 1.2f;
        _healthbar.maxValue *= 1.2f;
    }
}
