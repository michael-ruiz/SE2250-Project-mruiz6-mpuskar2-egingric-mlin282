using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenExitDoor : MonoBehaviour
{
    private bool _allEnemiesGone = false;
    private Collider2D _exitDoor;
    private GameObject[] _enemies;

    // Start is called before the first frame update
    void Start()
    {
        _exitDoor = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (_enemies.Length == 0 || _enemies == null)
        {
            _allEnemiesGone = true;
            _exitDoor.offset = new Vector2(_exitDoor.offset.x, 59.5f);
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
