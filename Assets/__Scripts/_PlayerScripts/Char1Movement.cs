using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char1Movement : PlayerMovement
{
    protected override void UniqueMovement()
    {
        if (Input.GetKey(KeyCode.E))
        {
            speed = defaultSpeed / 2;
        }
        else
        {
            speed = defaultSpeed;
        }
    }
}
