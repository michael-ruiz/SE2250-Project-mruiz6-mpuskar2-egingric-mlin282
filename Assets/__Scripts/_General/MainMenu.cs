using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Variables to disable or enable certain player attributes
    public static bool bomb;
    public static bool shuriken = true;

    // Variables to select the character
    public static bool character3;
    public static bool character2;
    public static bool character1;

    // Main Menu buttons
    public Button shurikenButton;
    public Button bombButton;
    public Button knifeButton;
    public Button bowButtonC2;

    void Start()
    {
        shurikenButton.interactable = false;
        bombButton.interactable = false;
        knifeButton.interactable = false;
        bowButtonC2.interactable = false;
    }

    public void Character3Select()
    {
        character3 = true;
        shurikenButton.interactable = true;
        bombButton.interactable = true;

        // Character 2
        knifeButton.interactable = false;
        bowButtonC2.interactable = false;

        // Character 1
        character1 = false;
    }

    public void Character2Select()
    {
        character2 = true;
        knifeButton.interactable = true;
        bowButtonC2.interactable = true;

        // Character 3
        character3 = false;
        shurikenButton.interactable = false;
        bombButton.interactable = false;

        // Character 1
        character1 = false;
    }

    public void Character1Select()
    {
        character1 = true;
        shurikenButton.interactable = true;
        bombButton.interactable = true;

        // Character 3
        character3 = false;
        shurikenButton.interactable = false;
        bombButton.interactable = false;

        // Character 2
        character2 = false;
    }


    public void BombSelect()
    {
        bomb = true;
        shuriken = false;
    }

    public void ShurikenSelect()
    {
        bomb = false;
        shuriken = true;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }
}
