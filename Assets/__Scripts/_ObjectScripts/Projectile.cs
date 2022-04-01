using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 5;
    public float baseDamage = 5;
    public static float damageMultiplier = 1;
    public float timeToDelete = 0.7f;
    public GameObject fromWhere;

    private void Start()
    {
        damage = baseDamage;
    }

    private void Update()
    {
        // Destroy the projectile a short time after creating it
        StartCoroutine(ExecuteAfterTime(timeToDelete));
    }

    // When it hits wall, enemy or player deal damage and destroy
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject != null && fromWhere.gameObject != null)
        {
            if (other.gameObject.CompareTag("Enemy") && fromWhere.CompareTag("Player"))
            {
                other.GetComponent<Health>().UpdateHealth(-damage * damageMultiplier);
                Destroy(gameObject);
            }

            if (other.gameObject.CompareTag("Player") && fromWhere.CompareTag("Enemy"))
            {
                other.GetComponent<Health>().UpdateHealth(-damage);
                Destroy(gameObject);
            }

            if (other.gameObject.CompareTag("Wall"))
            {
                Destroy(gameObject);
            }
        }
        
    }

    protected IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        Destroy(gameObject);
    }
}
