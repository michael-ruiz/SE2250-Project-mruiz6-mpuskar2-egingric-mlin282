using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Rigidbody2D player;
    private GameObject[] _cameras;
    public GameObject activeCamera;
    private float _roomWidth = 22;
    private float _roomHeight = 14;

    public Canvas score;

    // Start is called before the first frame update
    void Start()
    {
        _cameras = GameObject.FindGameObjectsWithTag("Camera");

        foreach (GameObject camera in _cameras)
        {
            camera.SetActive(false);
        }

        if (activeCamera == null)
        {
            activeCamera = _cameras[0];
        }

        activeCamera.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPos = player.position;

        foreach (GameObject camera in _cameras)
        {
            Vector2 cameraPos = camera.transform.position;
            bool withinX = playerPos.x > cameraPos.x - _roomWidth / 2 && playerPos.x <= cameraPos.x + _roomWidth / 2;
            bool withinY = playerPos.y > cameraPos.y - _roomHeight / 2 && playerPos.y <= cameraPos.y + _roomHeight / 2;

            if (withinX && withinY)
            {
                activeCamera.SetActive(false);
                
                activeCamera = camera;
                score.transform.SetParent(activeCamera.transform);
            }
        }

        activeCamera.SetActive(true);
    }
}