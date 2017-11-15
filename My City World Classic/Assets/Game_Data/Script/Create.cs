using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Create : MonoBehaviour
{

    //开始
    void Start()
    {
        Block.text = "石头";
        Debug.Log("CopyLeft(C)2017 AngelGameStdio  All rights reserved.");
        HH.x = Screen.width / 2;
        HH.y = Screen.height / 2;
    }

    public Vector2[] A = new Vector2[2];
    public GameObject Fz_Cube;
    Vector3 Pos;
    GameObject D_Cube;
    public GameObject[] Fz_Cubes = new GameObject[10];
    Vector2 HH;
    public Text Block;
    public int BlockNum;
    public Material[] NewBlockMaterial = new Material[10];

    void Update()
    {
        if (Input.GetKey(KeyCode.Backspace))
        {
            Application.Quit();
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(HH);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit,12))
            {
                print(hit.point);
                Vector3 Point = hit.point;
                Vector3 Pos = hit.transform.position;
                Vector3 FZ_Pos = Pos;
                if (Point.x >= Pos.x + 0.5)
                {
                    FZ_Pos.x = FZ_Pos.x + 1;
                    Instantiate(Fz_Cube, FZ_Pos, hit.transform.rotation);
                    return;
                }
                if (Point.x <= Pos.x - 0.5)
                {
                    FZ_Pos.x = FZ_Pos.x - 1;
                    Instantiate(Fz_Cube, FZ_Pos, hit.transform.rotation);
                    return;
                }
                if (Point.y >= Pos.y + 0.5)
                {
                    FZ_Pos.y = FZ_Pos.y + 1;
                    Instantiate(Fz_Cube, FZ_Pos, hit.transform.rotation);
                    return;
                }
                if (Point.y <= Pos.y - 0.5)
                {
                    FZ_Pos.y = FZ_Pos.y - 1;
                    Instantiate(Fz_Cube, FZ_Pos, hit.transform.rotation);
                    return;
                }
                if (Point.z >= Pos.z + 0.5)
                {
                    FZ_Pos.z = FZ_Pos.z + 1;
                    Instantiate(Fz_Cube, FZ_Pos, hit.transform.rotation);
                    return;
                }
                if (Point.z <= Pos.z - 0.5)
                {
                    FZ_Pos.z = FZ_Pos.z - 1;
                    Instantiate(Fz_Cube, FZ_Pos, hit.transform.rotation);
                    return;
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(HH);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit,12))
            {
                Pos = hit.transform.position;
                D_Cube = hit.transform.gameObject;
                Debug.Log(D_Cube.name);
                Destroy(D_Cube);
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            BlockNum = BlockNum + 1;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            BlockNum = BlockNum - 1;
        }
        Block.text = Fz_Cube.name;
        if (BlockNum == Fz_Cubes.Length)
        {
            BlockNum = 0;
        }
        if (BlockNum < 0)
        {
            BlockNum = Fz_Cubes.Length-1;
        }
        Fz_Cube = Fz_Cubes[BlockNum];
    }
}
