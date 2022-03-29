using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelMenu : MonoBehaviour
{
    private static GameObject _nextLevelMenu;

    void Start()
    {
        _nextLevelMenu = GameObject.Find("NextLevelMenu");
        _nextLevelMenu.SetActive(false);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene("Level2");
    }

    public void CharacterSelect()
    {
        SceneManager.LoadScene("CharacterSelect");
    }

    public static void OpenMenu()
    {
        _nextLevelMenu.SetActive(true);
    }
}
