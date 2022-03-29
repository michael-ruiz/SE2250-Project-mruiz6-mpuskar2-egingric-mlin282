using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    private static GameObject _deathMenu;

    void Start()
    {
        _deathMenu = GameObject.Find("DeathMenu");
        _deathMenu.SetActive(false);
    }

    public void Retry()
    {
        if (MainMenu.currentLvl == 1)
        {
            SceneManager.LoadScene("Level1");
        }
        if (MainMenu.currentLvl == 2)
        {
            SceneManager.LoadScene("Level2");
        }

    }

    public void CharacterSelect()
    {
        SceneManager.LoadScene("CharacterSelect");
    }

    public static void OpenDeathMenu()
    {
        _deathMenu.SetActive(true);
    }
}
