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
                obj.GetComponent<Bomb>().fromWhere = gameObject;
                obj.transform.position = transform.position;
                _placeCooldown = 0;
            }
        }

        _placeCooldown += Time.fixedDeltaTime;
    }

    public void EnemyDropBomb()
    {
        GameObject obj = Instantiate(bombPrefab);
        obj.transform.localScale = new Vector3(2, 2, 1);
        obj.GetComponent<Bomb>().fromWhere = gameObject;
        obj.GetComponent<Bomb>().radius = 8;
        obj.GetComponent<Bomb>().damage = 40;
        obj.transform.position = transform.position;
    }
}
