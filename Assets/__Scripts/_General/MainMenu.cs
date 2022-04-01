using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Variables to disable or enable certain player attributes
    public static int currentLvl = 0;
    public Button confirmSelection;

    // Character 3
    public static bool character3;
    public static bool bomb;
    public static bool shuriken = true;
    public Button shurikenButton;
    public Button bombButton;

    // Character 2
    public static bool character2;
    public static bool knife;
    public static bool bowC2 = true;
    public Button knifeButton;
    public Button bowButtonC2;

    // Character 1
    public static bool character1;
    public static bool bowC1;
    public static bool sword = true;
    public Button swordButton;
    public Button bowButtonC1;

    void Start()
    {
        shurikenButton.interactable = false;
        bombButton.interactable = false;
        knifeButton.interactable = false;
        bowButtonC2.interactable = false;
        swordButton.interactable = false;
        bowButtonC1.interactable = false;
        confirmSelection.interactable = false;
    }

    public void Character3Select()
    {
        character3 = true;
        shurikenButton.interactable = true;
        bombButton.interactable = true;
        confirmSelection.interactable = true;

        // Character 2
        character2 = false;
        knifeButton.interactable = false;
        bowButtonC2.interactable = false;

        // Character 1
        character1 = false;
        swordButton.interactable = false;
        bowButtonC1.interactable = false;
    }

    public void Character2Select()
    {
        character2 = true;
        knifeButton.interactable = true;
        bowButtonC2.interactable = true;
        confirmSelection.interactable = true;

        // Character 3
        character3 = false;
        shurikenButton.interactable = false;
        bombButton.interactable = false;

        // Character 1
        character1 = false;
        swordButton.interactable = false;
        bowButtonC1.interactable = false;
    }

    public void Character1Select()
    {
        character1 = true;
        swordButton.interactable = true;
        bowButtonC1.interactable = true;
        confirmSelection.interactable = true;

        // Character 3
        character3 = false;
        shurikenButton.interactable = false;
        bombButton.interactable = false;

        // Character 2
        character2 = false;
        knifeButton.interactable = false;
        bowButtonC2.interactable = false;
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

    public void KnifeSelect()
    {
        knife = true;
        bowC2 = false;
    }

    public void BowSelectC2()
    {
        knife = false;
        bowC2 = true;
    }

    public void SwordSelect()
    {
        sword = true;
        bowC1 = false;
    }

    public void BowSelectC1()
    {
        sword = false;
        bowC1 = true;
    }

    public void PlayGame()
    {
        if (currentLvl == 0)
        {
            currentLvl = 1;
        }
        if (currentLvl == 1)
        {
            SceneManager.LoadScene("Level1");
        }
        if (currentLvl == 2)
        {
            SceneManager.LoadScene("Level2");
        }
    }
}
