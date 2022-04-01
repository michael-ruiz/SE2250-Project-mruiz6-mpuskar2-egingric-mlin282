using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossRoomDoor : MonoBehaviour
{
    private GameObject _notReadyMenu;
    private bool _isScoreUnlockBossRoom = false;

    public static int objCounter = 0;
    public static int totalCollectables = 8;
    private static Slider _counter;

    // Start is called before the first frame update
    void Start()
    {
        _notReadyMenu = GameObject.Find("NotReady");
        _notReadyMenu.SetActive(false);

        objCounter = 0;
        _counter = GameObject.FindGameObjectWithTag("CollectableCounter").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health.score >= Health.maxScore)
        {
            _isScoreUnlockBossRoom = true;
        }

        if (_isScoreUnlockBossRoom || objCounter >= (totalCollectables / 2))
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

    public static void IncrementCollectibles()
    {
        objCounter++;
        _counter.value = objCounter;
    }
}
