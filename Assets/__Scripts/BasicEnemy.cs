using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public float speed = 2.5f;
    public float damage = 10;
    public float radius = 4;
    protected float _attackSpeed = 1;
    protected GameObject _target;
    protected float _attackCooldown;
    protected float _attackRadius = 1;

    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        Attack();

        _attackCooldown += Time.fixedDeltaTime;
    }

    protected virtual void Attack()
    {
        float distanceFromTarget = Vector2.Distance(transform.position, _target.transform.position);

        if (distanceFromTarget < radius)
        {
            float step = speed * Time.fixedDeltaTime;
            transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, step);
        }

        if (distanceFromTarget < _attackRadius)
        {
            if (_attackSpeed <= _attackCooldown)
            {
                _target.GetComponent<Health>().UpdateHealth(-damage);
                _attackCooldown = 0;
            }
        }
    }
}
