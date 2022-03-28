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
            GameObject char3 = Instantiate(character3);
            char3.GetComponent<PlayerRangedAttack>().enabled = MainMenu.shuriken;
            char3.GetComponent<DropBomb>().enabled = MainMenu.bomb;
        }
        else if (MainMenu.character2)
        {
            GameObject char2 = Instantiate(character2);
            if (MainMenu.knife)
            {
                char2.GetComponent<MeleeAttack>().baseDamage *= 2;
                char2.GetComponent<MeleeAttack>().startTimeBtwnAttack *= 0.5f;
            }
            char2.GetComponent<PlayerRangedAttack>().enabled = MainMenu.bow;
        }
        else if (MainMenu.character1)
        {
            //GameObject char1 = Instantiate(character1);
        }
    }
}
