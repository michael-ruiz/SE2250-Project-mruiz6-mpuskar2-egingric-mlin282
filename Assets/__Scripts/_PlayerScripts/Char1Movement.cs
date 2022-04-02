using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char1Movement : PlayerMovement
{
    // Updated every fixed amount of frames
    void FixedUpdate()
    {
        if (animator != null)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }

        if (Input.GetKey(KeyCode.E))
        {
            speed = defaultSpeed / 2;
        }
        else
        {
            speed = defaultSpeed;
        }

        // Check if the multiplier is greater than 1, and if it is reset it after 5 seconds
        if (speedMultiplier > 1)
        {
            StartCoroutine(base.ResetMultiplierDelay(5));
        }

        rb.MovePosition(rb.position + speed * speedMultiplier * Time.fixedDeltaTime * movement.normalized);
    }
}
