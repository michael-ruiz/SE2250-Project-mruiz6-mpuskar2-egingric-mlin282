using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char2Movement : PlayerMovement
{
    protected override void UniqueMovement()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (3 <= dashCooldown)
            {
                speed = 25;
                dashCooldown = 0;
                StartCoroutine(base.ExecuteAfterTime(0.1f)); // Delay of 0.1 seconds
            }
        }
    }
}
