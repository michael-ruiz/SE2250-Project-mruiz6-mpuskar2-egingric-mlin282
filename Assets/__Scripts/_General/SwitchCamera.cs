using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public static GameObject activeCamera;
    private Canvas _score;
    private Rigidbody2D _player;
    private GameObject[] _cameras;
    private List<GameObject> _visitedRooms = new List<GameObject>();
    private float _roomWidth = 22;
    private float _roomHeight = 14;

    // Start is called before the first frame update
    void Start()
    {
        _cameras = GameObject.FindGameObjectsWithTag("Camera");
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        _score = GameObject.FindGameObjectWithTag("UI").GetComponent<Canvas>();

        foreach (GameObject camera in _cameras)
        {
            camera.SetActive(false);
        }

        if (activeCamera == null)
        {
            activeCamera = _cameras[0];
            _visitedRooms.Add(activeCamera);
        }

        activeCamera.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (_player != null)
        {
            Vector2 playerPos = _player.position;

            foreach (GameObject camera in _cameras)
            {
                Vector2 cameraPos = camera.transform.position;
                bool withinX = playerPos.x > cameraPos.x - _roomWidth / 2 && playerPos.x <= cameraPos.x + _roomWidth / 2;
                bool withinY = playerPos.y > cameraPos.y - _roomHeight / 2 && playerPos.y <= cameraPos.y + _roomHeight / 2;

                if (withinX && withinY)
                {
                    activeCamera.SetActive(false);

                    activeCamera = camera;
                    _score.transform.SetParent(activeCamera.transform);
                }
            }

            activeCamera.SetActive(true);
            if (!_visitedRooms.Contains(activeCamera))
            {
                InstantiateEnemies.GenerateRoom(1);
                _visitedRooms.Add(activeCamera);
            }
        }
    }
}
