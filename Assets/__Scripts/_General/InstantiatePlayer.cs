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
        }
        else if (MainMenu.character2)
        {
            Instantiate(character2);
        }
        else if (MainMenu.character1)
        {
            //Instantiate(character1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
