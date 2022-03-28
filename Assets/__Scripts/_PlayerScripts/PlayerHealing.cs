using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealing : MonoBehaviour
{
    // Can only heal every 45 seconds
    private float _healSpeed = 45;
    private float _healCooldown;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (_healSpeed <= _healCooldown)
            {
                this.GetComponent<Health>().UpdateHealth(20);
                _healCooldown = 0;
            }
        }

        _healCooldown += Time.fixedDeltaTime;
    }
}
