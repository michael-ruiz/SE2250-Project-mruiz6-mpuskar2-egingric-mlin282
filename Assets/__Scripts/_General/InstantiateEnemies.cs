using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemies : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemy1).transform.position = new Vector3(20, 4);
        Instantiate(enemy2).transform.position = new Vector3(25, -4);
        Instantiate(enemy2).transform.position = new Vector3(-9, -9);
        Instantiate(enemy1).transform.position = new Vector3(9, -9);
    }
}
