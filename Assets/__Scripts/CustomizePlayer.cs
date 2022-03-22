using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizePlayer : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<PlayerRangedAttack>().enabled = MainMenu.shuriken;
        this.GetComponent<DropBomb>().enabled = MainMenu.bomb;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
