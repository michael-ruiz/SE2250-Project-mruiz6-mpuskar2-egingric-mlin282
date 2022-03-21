using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 5;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Health>().UpdateHealth(-damage);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
