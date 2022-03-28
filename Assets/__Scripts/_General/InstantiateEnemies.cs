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
        if (MainMenu.currentLvl == 1)
        {
            _posInRoom = new Vector3[5];
            _posInRoom[0] = new Vector3(6.5f, 3, 0);
            _posInRoom[1] = new Vector3(-6.5f, 3, 0);
            _posInRoom[2] = new Vector3(6.5f, -3, 0);
            _posInRoom[3] = new Vector3(-6.5f, -3, 0);
            _posInRoom[4] = new Vector3(0, 0, 0);

            enemy1 = enemy1Prefab;
            enemy2 = enemy2Prefab;
        }

        if (MainMenu.currentLvl == 2)
        {
            // different locations for lvl 2
        }
    }

    public static void GenerateRoom(int lvl)
    {
        int range = 0;
        if (lvl == 1)
        {
            range = 3;
        }
        if (lvl == 2)
        {
            range = 4;
        }

        if (_posInRoom != null)
        {
            for (int i = 0; i < _posInRoom.Length; i++)
            {
                int objNum = Random.Range(0, range);
                Vector3 pos = SwitchCamera.activeCamera.transform.position + _posInRoom[i];

                switch (objNum)
                {
                    case 0:
                        PlaceObject(enemy1, pos);
                        break;

                    case 1:
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
