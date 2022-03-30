using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    public static int objCounter;
    public static int totalCollectables = 10;
    // How much to mutiply the player's speed by if it is a speed pickup
    public float speedMultiplier = 1.5f;
    // How much to increase the player's health by if it is a health pickup
    public int healthIncrease = 20;
    // How much to increase the player's damage by if it is a damage pickup
    public int damageMultiple = 2;
    private static Slider _counter;

    // Start is called before the first frame update
    void Start()
    {
        objCounter = 0;
        _counter = GameObject.FindGameObjectWithTag("CollectableCounter").GetComponent<Slider>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // When player collects object increament counter
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);

            if (gameObject.CompareTag("Collectable"))
            {
                objCounter++;
                _counter.value = objCounter;
            }
            else if (gameObject.CompareTag("SpeedPickup"))
            {
                PlayerMovement.speedMultiplier = speedMultiplier;
            }
            else if (gameObject.CompareTag("HealthPickup"))
            {
                collision.GetComponent<Health>().UpdateHealth(healthIncrease);
            }
            else if (gameObject.CompareTag("DamagePickup"))
            {
                collision.GetComponent<MeleeAttack>().damage *= damageMultiple;
                Projectile.damageMultiplier = damageMultiple;
                Bomb.damageMultiplier = damageMultiple;
            }
        }
    }
}
