using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedAttack : BasicEnemy
{

    public GameObject rangeProjectile;
    public int projSpeed = 25;
    private Rigidbody2D _rb;
    private GameObject projGO;

    protected override void Attack()
    {
        float distanceFromTarget = Vector2.Distance(transform.position, _target.transform.position);

        if (distanceFromTarget < maxRadius && distanceFromTarget > minRadius)
        {
            // Get player and enemy position and draw unit vector between them
            Vector2 enemyPos = transform.position;
            Vector2 playerPos = _target.transform.position;
            Vector2 projDir = new Vector2(playerPos.x - enemyPos.x, playerPos.y - enemyPos.y).normalized;

            if (attackSpeed <= _attackCooldown)
            {
                // Angle the projectile to be in the correct direction
                float angle = -Mathf.Atan2(projDir.x, projDir.y) * Mathf.Rad2Deg;

                // Instantiate the projectile and make it move in the direction of the player
                projGO = Instantiate(rangeProjectile);
                projGO.transform.position = transform.position;
                _rb = projGO.GetComponent<Rigidbody2D>();
                projGO.GetComponent<Projectile>().fromWhere = gameObject;
                _rb.velocity = projDir * projSpeed;
                _rb.rotation = angle;

                _attackCooldown = 0;
            }
        }
    }
}
