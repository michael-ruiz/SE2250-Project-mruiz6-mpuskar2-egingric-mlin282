using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    private float _damage = 5;
    private float _timer = 0;
    private float _damageDelay = 0.5f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Rigidbody2D>().WakeUp();

            if (_timer <= 0)
            {
                collision.GetComponent<Health>().UpdateHealth(-_damage);
                _timer = _damageDelay;
            }
            else
            {
                _timer -= Time.deltaTime;
            }
        }
    }
}
