using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomDoor : MonoBehaviour
{
    private GameObject _notReadyMenu;
    private bool isScoreUnlockBossRoom = false;

    // Start is called before the first frame update
    void Start()
    {
        _notReadyMenu = GameObject.Find("NotReady");
        _notReadyMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Health.score == Health.maxScore)
        {
            isScoreUnlockBossRoom = true;
        }

        if (isScoreUnlockBossRoom || Collectable.objCounter >= (Collectable.totalCollectables / 2))
        {
            GetComponent<Collider2D>().isTrigger = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _notReadyMenu.SetActive(true);
        }
    }

    public void CloseMenu()
    {
        _notReadyMenu.SetActive(false);
    }
}
