using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemies : MonoBehaviour
{
    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;
    public GameObject enemy3Prefab;
    private static Vector3[] _posInRoom;
    private static GameObject enemy1;
    private static GameObject enemy2;
    private static GameObject enemy3;

    // Start is called before the first frame update
    void Start()
    {
        enemy1 = enemy1Prefab;
        enemy2 = enemy2Prefab;
        enemy3 = enemy3Prefab;
    }

    public static void GenerateRoom(int lvl)
    {
        int range = 0;
        int start = 0;

        if (lvl == 1)
        {
            range = 3;
            _posInRoom = new Vector3[5];
            _posInRoom[0] = new Vector3(6.5f, 3, 0);
            _posInRoom[1] = new Vector3(-6.5f, 3, 0);
            _posInRoom[2] = new Vector3(6.5f, -3, 0);
            _posInRoom[3] = new Vector3(-6.5f, -3, 0);
            _posInRoom[4] = new Vector3(0, 0, 0);
        }
        if (lvl == 2)
        {
            range = 4;
            _posInRoom = new Vector3[3];
            _posInRoom[0] = new Vector3(5, 2, 0);
            _posInRoom[1] = new Vector3(-5, 2, 0);
            _posInRoom[2] = new Vector3(0, -3, 0);
        }
        if (lvl == 1 && SwitchCamera.activeCamera.Equals(GameObject.Find("CameraEnd")))
        {
            range = 3;
            start = 1;
            _posInRoom = new Vector3[10];
            _posInRoom[0] = new Vector3(7, 3, 0);
            _posInRoom[1] = new Vector3(-7, 3, 0);
            _posInRoom[2] = new Vector3(11, 0, 0);
            _posInRoom[3] = new Vector3(-11, 0, 0);
            _posInRoom[4] = new Vector3(4, 0, 0);
            _posInRoom[5] = new Vector3(-4, 0, 0);
            _posInRoom[6] = new Vector3(9, -3, 0);
            _posInRoom[7] = new Vector3(-9, -3, 0);
            _posInRoom[8] = new Vector3(5, -4, 0);
            _posInRoom[9] = new Vector3(-5, -4, 0);
        }
        if (lvl == 2 && SwitchCamera.activeCamera.Equals(GameObject.Find("CameraEnd")))
        {
            range = 4;
            start = 1;
            _posInRoom = new Vector3[6];
            _posInRoom[0] = new Vector3(0, 0, 0);
            _posInRoom[1] = new Vector3(7, 4, 0);
            _posInRoom[2] = new Vector3(11, 0, 0);
            _posInRoom[3] = new Vector3(-11, 0, 0);
            _posInRoom[4] = new Vector3(-5, 4, 0);
            _posInRoom[5] = new Vector3(0, 5, 0);
        }

        if (_posInRoom != null)
        {
            for (int i = 0; i < _posInRoom.Length; i++)
            {
                int objNum = Random.Range(start, range);
                Vector3 pos = SwitchCamera.activeCamera.transform.position + _posInRoom[i];

                switch (objNum)
                {
                    case 1:
                        PlaceObject(enemy1, pos);
                        break;

                    case 2:
                        PlaceObject(enemy2, pos);
                        break;

                    case 3:
                        PlaceObject(enemy3, pos);
                        break;

                    default: // Do nothing
                        break;
                }
            }
        }
    }

    static void PlaceObject(GameObject prefab, Vector2 pos)
    {
        GameObject obj = Instantiate(prefab);
        obj.transform.position = pos;
    }
}
