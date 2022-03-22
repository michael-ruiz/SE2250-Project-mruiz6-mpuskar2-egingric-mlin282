using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 5;
    public GameObject fromWhere;

    private void Update()
    {
        // Destroy the projectile 0.5 seconds after creating it
        StartCoroutine(ExecuteAfterTime(0.5f));
    }

    // When it hits wall, enemy or player deal damage and destroy
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" && fromWhere.tag == "Player")
        {
            other.GetComponent<Health>().UpdateHealth(-damage);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Player" && fromWhere.tag == "Enemy")
        {
            other.GetComponent<Health>().UpdateHealth(-damage);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        Destroy(gameObject);
    }
}
