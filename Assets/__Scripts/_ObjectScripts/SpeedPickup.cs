using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickup : MonoBehaviour
{
    // How much to mutiply the player's speed by
    public float speedMultiplier = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // When player collects object increament counter
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            PlayerMovement.speedMultiplier = speedMultiplier;
        }
    }
}
