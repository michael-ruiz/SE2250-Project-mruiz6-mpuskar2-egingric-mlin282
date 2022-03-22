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
    public float damage;

    // Update is called once per frame
    void Update()
    {
        if (timeBtwnAttack <= 0)
        {
            if (Input.GetKey(KeyCode.X))
            {
                Collider2D[] enemiesToDmg = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for(int i = 0; i< enemiesToDmg.Length; i++)
                {
                    enemiesToDmg[i].GetComponent<Health>().UpdateHealth(-damage);
                }

            }
            timeBtwnAttack = startTimeBtwnAttack;
        }
        else
        {
            timeBtwnAttack -= Time.deltaTime;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position,attackRange);
    }
}
