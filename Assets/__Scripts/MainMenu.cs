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

    // Main Menu buttons
    public Button shurikenButton;
    public Button bombButton;

    void Start()
    {
        shurikenButton.interactable = false;
        bombButton.interactable = false;
    }

    public void Character3Select()
    {
        character3 = true;
        shurikenButton.interactable = true;
        bombButton.interactable = true;
        // When more characters added, make sure to disable their selection buttons here
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
