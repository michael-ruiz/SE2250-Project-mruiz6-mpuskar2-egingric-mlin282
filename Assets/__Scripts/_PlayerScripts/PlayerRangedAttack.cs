using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangedAttack : MonoBehaviour
{
    public GameObject rangeProjectile;
    public int projSpeed = 15;
    private Rigidbody2D _rb;
    private GameObject projGO;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Get mouse position on screen
        Vector3 mousePos = Input.mousePosition;

        // Get player position relative to screen
        Camera activeCam = SwitchCamera.activeCamera.GetComponent<Camera>();
        Vector3 screenPos = activeCam.WorldToScreenPoint(transform.position);

        // Make unit vector for projectile direction
        Vector3 projDir = new Vector3(mousePos.x - screenPos.x, mousePos.y - screenPos.y, 0).normalized;

        // Instantiate the projectile and make it move in the direction of the mouse
        projGO = Instantiate(rangeProjectile);
        projGO.transform.position = transform.position;
        _rb = projGO.GetComponent<Rigidbody2D>();
        projGO.GetComponent<Projectile>().fromWhere = gameObject;
        _rb.velocity = projDir * projSpeed;

        if (MainMenu.bowC2 || MainMenu.bowC1)
        {
            // Angle the projectile to be in the correct direction
            float angle = -Mathf.Atan2(projDir.x, projDir.y) * Mathf.Rad2Deg;
            _rb.rotation = angle;
        }
    }

    public void ResetChar1Damage()
    {
        // Reset all player done damage values after 10 seconds
        StartCoroutine(ResetDamageDelay(10));
    }

    IEnumerator ResetDamageDelay(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        Projectile.damageMultiplier = 1;
    }
}
