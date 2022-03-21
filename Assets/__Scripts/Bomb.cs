using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float _timer = 2;
    private bool _notExploded = true;
    public GameObject bombArea;

    void FixedUpdate()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 1.5f);

        if (_notExploded)
        {
            _timer -= Time.smoothDeltaTime;

            if(_timer < 0)
            {
                foreach (Collider2D c in hits)
                {
                    if (c.gameObject.tag == "Player")
                    {
                        c.GetComponent<Health>().UpdateHealth(-20);
                        _notExploded = false;
                    }
                }

                Destroy(gameObject);
            }
        }
    }
}
