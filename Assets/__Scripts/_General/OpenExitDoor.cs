using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenExitDoor : MonoBehaviour
{
    private bool _allEnemiesGone = false;
    private Collider2D _exitDoor;

    // Start is called before the first frame update
    void Start()
    {
        _exitDoor = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            _allEnemiesGone = true;
            if (MainMenu.currentLvl == 1)
            {
                _exitDoor.offset = new Vector2(_exitDoor.offset.x, 59.5f);
            }
            if (MainMenu.currentLvl == 2)
            {
                _exitDoor.offset = new Vector2(_exitDoor.offset.x, 97.5f);
            }
        }

        else
        {
            _allEnemiesGone = false;
            if (MainMenu.currentLvl == 1)
            {
                _exitDoor.offset = new Vector2(_exitDoor.offset.x, 58);
            }
            if (MainMenu.currentLvl == 2)
            {
                _exitDoor.offset = new Vector2(_exitDoor.offset.x, 96);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && _allEnemiesGone)
        {
            MainMenu.currentLvl = 2;
            Destroy(collision.gameObject);
            NextLevelMenu.OpenMenu();
        }
    }
}
