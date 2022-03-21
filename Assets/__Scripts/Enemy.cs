using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2.5f;
    private Transform _target;
    private float _attackDamage = 10;
    private float _attackSpeed = 1;
    private float _attackCooldown;

    void FixedUpdate()
    {
        if (_target != null)
        {
            float step = speed * Time.fixedDeltaTime;
            transform.position = Vector2.MoveTowards(transform.position, _target.position, step);
        }

        _attackCooldown += Time.deltaTime;
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
                collision.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-_attackDamage);
                _attackCooldown = 0;
            }
        }
    }
}
