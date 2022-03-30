using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    private float timeBtwnAttack;
    public float startTimeBtwnAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public float baseDamage = 20;
    public float damage;

    void Start()
    {
        damage = baseDamage;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwnAttack <= 0)
        {
            if (Input.GetMouseButton(1) || Input.GetKey(KeyCode.X))
            {
                Collider2D[] enemiesToDmg = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for(int i = 0; i< enemiesToDmg.Length; i++)
                {
                    enemiesToDmg[i].GetComponent<Health>().UpdateHealth(-damage);
                }
                timeBtwnAttack = startTimeBtwnAttack;
            }
        }
        else
        {
            timeBtwnAttack -= Time.deltaTime;
        }

        if (damage != baseDamage)
        {
            // Reset all player done damage values after 10 seconds
            StartCoroutine(ResetDamageDelay(10));
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position,attackRange);
    }

    IEnumerator ResetDamageDelay(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        damage = baseDamage;
        Projectile.damageMultiplier = 1;
        Bomb.damageMultiplier = 1;
    }
}
