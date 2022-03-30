using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char1Movement : PlayerMovement
{
    // Updated every fixed amount of frames
    void FixedUpdate()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKey(KeyCode.Space))
        {
            if (3 <= dashCooldown)
            {
                speed = 50;
                dashCooldown = 0;
                StartCoroutine(base.ExecuteAfterTime(0.1f)); // Delay of 0.1 seconds
            }
        }

        if (Input.GetKey(KeyCode.E))
        {
            speed = 2.5f;
        }
        else
        {
            speed = 5;
        }

        // Check if the multiplier is greater than 1, and if it is reset it after 5 seconds
        if (speedMultiplier > 1)
        {
            StartCoroutine(base.ResetMultiplierDelay(5));
        }

        dashCooldown += Time.fixedDeltaTime;
        rb.MovePosition(rb.position + speed * speedMultiplier * Time.fixedDeltaTime * movement.normalized);
    }
}
