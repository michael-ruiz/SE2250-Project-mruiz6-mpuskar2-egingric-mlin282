using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerLevelUp : MonoBehaviour
{
    private Slider _scorebar;
    private TextMeshProUGUI _levelUpText;

    // Start is called before the first frame update
    void Start()
    {
        _scorebar = GameObject.FindGameObjectWithTag("Score").GetComponent<Slider>();
        _levelUpText = GameObject.FindGameObjectWithTag("LevelUpText").GetComponent<TextMeshProUGUI>();
        _levelUpText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health.score >= Health.maxScore)
        {
            // Reset bar and allow excess score to carry over
            Health.score %= Health.maxScore;
            _scorebar.value %= Health.maxScore;

            if (GetComponent<Char1Movement>() != null) // Character 1
            {
                // Update health
                GetComponent<Health>().IncreaseMaxHealth();

                _levelUpText.text = "Level Up! Max health increased";
                _levelUpText.enabled = true;
                StartCoroutine(HideLevelUpTextDelay(5));
            }
            else if (GetComponent<Char2Movement>() != null) // Character 2
            {
                // Update damage
                GetComponent<MeleeAttack>().damage *= 1.1f;
                GetComponent<MeleeAttack>().baseDamage *= 1.1f;
                GetComponent<PlayerRangedAttack>().rangeProjectile.GetComponent<Projectile>().damage *= 1.1f;

                _levelUpText.text = "Level Up! Max damage increased";
                _levelUpText.enabled = true;
                StartCoroutine(HideLevelUpTextDelay(5));
            }
            else if (GetComponent<PlayerMovement>() != null) // Character 3
            {
                // Update speed
                GetComponent<PlayerMovement>().speed *= 1.05f;
                GetComponent<PlayerMovement>().defaultSpeed *= 1.05f;

                _levelUpText.text = "Level Up! Max speed increased";
                _levelUpText.enabled = true;
                StartCoroutine(HideLevelUpTextDelay(5));
            }
        }
    }

    IEnumerator HideLevelUpTextDelay(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        _levelUpText.enabled = false;
    }
}
