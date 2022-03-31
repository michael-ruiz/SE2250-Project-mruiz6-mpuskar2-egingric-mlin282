using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelUp : MonoBehaviour
{
    private Slider _scorebar;
    private Slider _healthbar;

    // Start is called before the first frame update
    void Start()
    {
        _scorebar = GameObject.FindGameObjectWithTag("Score").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health.score == Health.maxScore)
        {
            Health.score = 0;
            _scorebar.value = 0;

            if (GetComponent<Char1Movement>() != null)
            {
                // Update health
                GetComponent<Health>().IncreaseMaxHealth();
            }
            else if (GetComponent<Char2Movement>() != null)
            {
                // Update damage
                GetComponent<MeleeAttack>().damage *= 1.05f;
                GetComponent<MeleeAttack>().baseDamage *= 1.05f;
                GetComponent<PlayerRangedAttack>().rangeProjectile.GetComponent<Projectile>().damage *= 1.05f;
            }
            else if (GetComponent<PlayerMovement>() != null)
            {
                // Update speed
                GetComponent<PlayerMovement>().speed *= 1.05f;
                GetComponent<PlayerMovement>().defaultSpeed *= 1.05f;
            }
        }
    }
}
