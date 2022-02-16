using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Rigidbody2D player;
    private GameObject[] _cameras;
    private GameObject _activeCamera;
    private float _roomWidth = 22f;
    private float _roomHeight = 14f;

    // Start is called before the first frame update
    void Start()
    {
        _cameras = GameObject.FindGameObjectsWithTag("Camera");

        foreach (GameObject camera in _cameras)
        {
            camera.SetActive(false);
        }

        if (_activeCamera == null)
        {
            _activeCamera = _cameras[0];
        }

        _activeCamera.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPos = player.transform.position;

        foreach (GameObject camera in _cameras)
        {
            Vector2 cameraPos = camera.transform.position;
            bool withinX = playerPos.x > cameraPos.x - _roomWidth / 2 && playerPos.x <= cameraPos.x + _roomWidth / 2;
            bool withinY = playerPos.y > cameraPos.y - _roomHeight / 2 && playerPos.y <= cameraPos.y + _roomHeight / 2;

            if (withinX && withinY)
            {
                _activeCamera.SetActive(false);
                _activeCamera = camera;
            }
        }

        _activeCamera.SetActive(true);
    }
}
