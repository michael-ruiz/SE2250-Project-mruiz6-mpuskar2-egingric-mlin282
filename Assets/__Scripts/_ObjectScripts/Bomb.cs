using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float _timer = 2;
    private bool _notExploded = true;
    public GameObject bombArea;
    public float damage = 20;
    public static float damageMultiplier = 1;
    public GameObject fromWhere;
    public float radius = 2;

    void FixedUpdate()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius);

        if (_notExploded)
        {
            _timer -= Time.smoothDeltaTime;

            if(_timer < 0)
            {
                foreach (Collider2D c in hits)
                {
                    if ((c.gameObject.CompareTag("Player") || c.gameObject.CompareTag("Enemy")) && fromWhere != null)
                    {
                        c.GetComponent<Health>().UpdateHealth(-damage * damageMultiplier);
                        _notExploded = false;
                    }
                    if (c.gameObject.CompareTag("Player") || c.gameObject.CompareTag("Enemy") && fromWhere == null)
                    {
                        c.GetComponent<Health>().UpdateHealth(-damage);
                        _notExploded = false;
                    }
                }

                Destroy(gameObject);
            }
        }
    }
}
