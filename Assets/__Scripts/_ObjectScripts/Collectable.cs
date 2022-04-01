using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    // How much to mutiply the player's speed by if it is a speed pickup
    public float speedMultiplier = 1.5f;
    // How much to increase the player's health by if it is a health pickup
    public int healthIncrease = 20;
    // How much to increase the player's damage by if it is a damage pickup
    public int damageMultiple = 2;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // When player collects object increament counter
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Collectable"))
            {
                BossRoomDoor.IncrementCollectibles();
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

                // Reset character 1 damage if he has the bow (reset method in MeleeAttack is inaccesible)
                if (collision.gameObject.GetComponent<Char1Movement>() != null && !collision.gameObject.GetComponent<MeleeAttack>().enabled)
                {
                    collision.gameObject.GetComponent<PlayerRangedAttack>().ResetChar1Damage();
                }
            }

            Destroy(gameObject);
        }
    }
}
