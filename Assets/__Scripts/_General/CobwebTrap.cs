using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CobwebTrap : MonoBehaviour
{
    private float _reduce = 0.3f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.GetComponent<PlayerMovement>() != null)
        {
            PlayerMovement.speedMultiplier = _reduce;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.GetComponent<PlayerMovement>() != null)
        {
            PlayerMovement.speedMultiplier = 1;
        }
    }
}
