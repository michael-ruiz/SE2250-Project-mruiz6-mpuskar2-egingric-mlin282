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
    void Start()
    {
        // Depending on the choosen character, the others are destroyed (All characters are in hierarchy at start and the unused are deleted)
        // Most code is commented because other characters don't exist yet
        // Doing it this way because other way didn't want to work :)
        if (MainMenu.character3)
        {
            //Instantiate(character3);
            //Destroy(character2);
            //Destroy(character1);
        }
        else if (MainMenu.character2)
        {
            //Instantiate(character2);
            Destroy(character3);
            //Destroy(character1);
        }
        else if (MainMenu.character1)
        {
            //Instantiate(character1);
            Destroy(character3);
            //Destroy(character2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
