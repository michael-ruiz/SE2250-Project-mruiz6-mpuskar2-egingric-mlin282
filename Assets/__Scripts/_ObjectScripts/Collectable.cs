using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public static int objCounter = 0;

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
        }
    }
}
