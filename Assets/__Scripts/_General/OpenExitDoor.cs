using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenExitDoor : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Add logic for when enemies are dead
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<Collider2D>().isTrigger = true;
            print("Done");
        }
    }
}
