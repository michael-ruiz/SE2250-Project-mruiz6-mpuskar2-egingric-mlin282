using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char2Movement : PlayerMovement
{
    // Updated every fixed amount of frames
    void FixedUpdate()
    {
        _animator.SetFloat("Horizontal", _movement.x);
        _animator.SetFloat("Vertical", _movement.y);
        _animator.SetFloat("Speed", _movement.sqrMagnitude);

        if (Input.GetKey(KeyCode.Space))
        {
            if (3 <= _dashCooldown)
            {
                speed = 50;
                _dashCooldown = 0;
                StartCoroutine(ExecuteAfterTime(0.1f)); // Delay of 0.1 seconds
            }
        }

        // Check if the multiplier is greater than 1, and if it is reset it after 5 seconds
        if (speedMultiplier > 1)
        {
            StartCoroutine(ResetMultiplierDelay(5));
        }

        _dashCooldown += Time.fixedDeltaTime;
        _rb.MovePosition(_rb.position + _movement.normalized * speed * speedMultiplier * Time.fixedDeltaTime);
    }
}
