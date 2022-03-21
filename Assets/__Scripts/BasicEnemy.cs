using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public float speed = 2.5f;
    public float attackDamage = 10;
    private float _attackSpeed = 1;
    private Transform _target;
    private float _attackCooldown;

    void FixedUpdate()
    {
        Move();

        _attackCooldown += Time.fixedDeltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _target = collision.transform;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (_attackSpeed <= _attackCooldown)
            {
                collision.gameObject.GetComponent<Health>().UpdateHealth(-attackDamage);
                _attackCooldown = 0;
            }
        }
    }

    protected virtual void Move()
    {
        if (_target != null)
        {
            float step = speed * Time.fixedDeltaTime;
            transform.position = Vector2.MoveTowards(transform.position, _target.position, step);
        }
    }
}
