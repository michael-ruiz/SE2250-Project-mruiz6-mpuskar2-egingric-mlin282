using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public float speed = 2.5f;
    public float damage = 10;
    protected float _attackSpeed = 1;
    protected Transform _target;
    protected float _attackCooldown;

    void FixedUpdate()
    {
        Move();

        _attackCooldown += Time.fixedDeltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        LongRange(collision);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        CloseRange(collision);
    }

    protected virtual void Move()
    {
        if (_target != null)
        {
            float step = speed * Time.fixedDeltaTime;
            transform.position = Vector2.MoveTowards(transform.position, _target.position, step);
        }
    }

    protected virtual void CloseRange(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (_attackSpeed <= _attackCooldown)
            {
                other.gameObject.GetComponent<Health>().UpdateHealth(-damage);
                _attackCooldown = 0;
            }
        }
        
    }

    protected virtual void LongRange(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _target = other.transform;
        }
    }
}
