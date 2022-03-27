using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public static int objCounter = 0;
    // How much to mutiply the player's speed by if it is a speed pickup
    public float speedMultiplier = 1.5f;
    // How much to increase the player's health by if it is a health pickup
    public int healthIncrease = 20;

    // Start is called before the first frame update
    void Start()
    {
        objCounter = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // When player collects object increament counter
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            objCounter++;

            if (gameObject.tag == "SpeedPickup")
            {
                PlayerMovement.speedMultiplier = speedMultiplier;
            }
            else if (gameObject.tag == "HealthPickup")
            {
                collision.GetComponent<Health>().IncreaseHealth(healthIncrease);
            }
        }
    }
}
