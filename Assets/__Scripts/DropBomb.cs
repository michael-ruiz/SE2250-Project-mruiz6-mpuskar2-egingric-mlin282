using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBomb : MonoBehaviour
{
    public GameObject bombPrefab;
    private float _placeSpeed = 5;
    private float _placeCooldown;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (_placeSpeed <= _placeCooldown)
            {
                GameObject obj = Instantiate(bombPrefab);
                obj.transform.position = transform.position;
                _placeCooldown = 0;
            }
        }

        _placeCooldown += Time.fixedDeltaTime;
    }
}
