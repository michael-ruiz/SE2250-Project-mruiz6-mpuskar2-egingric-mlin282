using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CobwebTrap : MonoBehaviour
{
    private float _reduce = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.GetComponent<PlayerMovement>() != null)
            {
                collision.GetComponent<PlayerMovement>().speed *= _reduce;
            }
            else if (collision.GetComponent<Char2Movement>() != null)
            {
                collision.GetComponent<Char2Movement>().speed *= _reduce;
            }
            else if (collision.GetComponent<Char1Movement>() != null)
            {
                // There is currently a bug with character 1 movement not being slowed down
                collision.GetComponent<Char1Movement>().speed *= _reduce;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.GetComponent<PlayerMovement>() != null)
            {
                collision.GetComponent<PlayerMovement>().speed = collision.GetComponent<PlayerMovement>().defaultSpeed;
            }
            else if (collision.GetComponent<Char2Movement>() != null)
            {
                collision.GetComponent<Char2Movement>().speed = collision.GetComponent<Char2Movement>().defaultSpeed;
            }
            else if (collision.GetComponent<Char1Movement>() != null)
            {
                collision.GetComponent<Char1Movement>().speed = collision.GetComponent<Char1Movement>().defaultSpeed;
            }
        }
    }
}
