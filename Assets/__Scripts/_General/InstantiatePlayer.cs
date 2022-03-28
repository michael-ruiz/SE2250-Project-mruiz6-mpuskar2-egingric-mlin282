using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach to starting camera
public class InstantiatePlayer : MonoBehaviour
{
    // Characters
    public GameObject character3;
    public GameObject character2;
    public GameObject character1;

    // Start is called before the first frame update
    void Awake()
    {
        // Instantiate the selected character
        if (MainMenu.character3)
        {
            Instantiate(character3);
            character3.GetComponent<PlayerRangedAttack>().enabled = MainMenu.shuriken;
            character3.GetComponent<DropBomb>().enabled = MainMenu.bomb;
        }
        else if (MainMenu.character2)
        {
            Instantiate(character2);
            if (MainMenu.knife)
            {
                // This does not work btw
                character2.GetComponent<MeleeAttack>().baseDamage *= 2;
                //this.GetComponent<MeleeAttack>().startTimeBtwnAttack *= 0.5f;
            }
            character2.GetComponent<PlayerRangedAttack>().enabled = MainMenu.bow;
        }
        else if (MainMenu.character1)
        {
            //Instantiate(character1);
        }
    }
}
