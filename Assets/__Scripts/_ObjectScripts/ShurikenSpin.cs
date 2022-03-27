using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenSpin : Projectile
{
    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 0, 500 * Time.deltaTime, Space.Self);
        // Destroy the projectile 0.7 seconds after creating it
        StartCoroutine(base.ExecuteAfterTime(timeToDelete));
    }
}
