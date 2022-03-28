using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangedAttack : MonoBehaviour
{
    public GameObject rangeProjectile;
    public int projSpeed = 15;
    private Rigidbody2D _rb;
    private GameObject projGO;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        // Left click
        /*        if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log(mousePos.x);
                    Debug.Log(mousePos.y);
                    Debug.Log("Pressed primary button.");
                }

                // Right click
                if (Input.GetMouseButtonDown(1))
                {
                    Debug.Log("Pressed secondary button.");
                }


                if (Input.GetMouseButtonDown(2))
                {
                    Debug.Log("Pressed middle click.");
                }*/
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
    }
}
