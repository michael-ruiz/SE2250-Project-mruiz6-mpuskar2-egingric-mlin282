using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTrap : MonoBehaviour
{
    private float _damage = 300;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Health>().UpdateHealth(-_damage);
        }
    }
}
