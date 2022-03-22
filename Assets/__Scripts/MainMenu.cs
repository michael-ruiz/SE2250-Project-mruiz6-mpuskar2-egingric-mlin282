using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public PlayerRangedAttack PlayerRangedAttack;
    public static bool bomb;
    public static bool shuriken;


    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void BombSelect()
    {
        //PlayerRangedAttack.enabled = false;
        //this.GetComponent<PlayerRangedAttack>().enabled = false;
        //GameObject.Find("Player1").GetComponent(PlayerRangedAttack).enabled = false;
        bomb = true;
        shuriken = false;
    }

    public void ShurikenSelect()
    {
        bomb = false;
        shuriken = true;
    }
}
