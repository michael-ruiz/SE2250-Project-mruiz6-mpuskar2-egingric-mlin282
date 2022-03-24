using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float _timer = 2;
    private bool _notExploded = true;
    public GameObject bombArea;
    public float damage = 20;

    void FixedUpdate()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 2);

        if (_notExploded)
        {
            _timer -= Time.smoothDeltaTime;

            if(_timer < 0)
            {
                foreach (Collider2D c in hits)
                {
                    if (c.gameObject.tag == "Player" || c.gameObject.tag == "Enemy")
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
