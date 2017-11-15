using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBlock : MonoBehaviour {

    public GameObject BasicBlock;
    public int Length = 16;
    public int BNum;
    public int y;
    // Use this for initialization
    void Start()
    {
        BNum = 1;
        Instantiate(BasicBlock, transform.position, transform.rotation);
        ScI(Length, BasicBlock, y);
    }

    void ScI(int Max, GameObject EndCube, int y)
    {
        for (int i = BNum; i < Max; i++)
        {
            Vector3 V3 = new Vector3(i, y, 0);
            Instantiate(EndCube, V3, transform.rotation);
        }
        for (int i = BNum; i < Max; i++)
        {
            Vector3 V3 = new Vector3(-i, y, 0);
            Instantiate(EndCube, V3, transform.rotation);
        }
        for (int i = BNum; i < Max; i++)
        {
            Vector3 V3 = new Vector3(0, y, i);
            Instantiate(EndCube, V3, transform.rotation);
        }
        for (int i = BNum; i < Max; i++)
        {
            Vector3 V3 = new Vector3(0, y, -i);
            Instantiate(EndCube, V3, transform.rotation);
        }
        for (int i = BNum; i < Max; i++)
        {
            for (int c = BNum; c < Max; c++)
            {
                Vector3 V3 = new Vector3(i, y, c);
                Instantiate(EndCube, V3, transform.rotation);
            }
        }
        for (int i = BNum; i < Max; i++)
        {
            for (int c = BNum; c < Max; c++)
            {
                Vector3 V3 = new Vector3(-i, y, c);
                Instantiate(EndCube, V3, transform.rotation);
            }
        }
        for (int i = BNum; i < Max; i++)
        {
            for (int c = BNum; c < Max; c++)
            {
                Vector3 V3 = new Vector3(i, y, -c);
                Instantiate(EndCube, V3, transform.rotation);
            }
        }
        for (int i = BNum; i < Max; i++)
        {
            for (int c = BNum; c < Max; c++)
            {
                Vector3 V3 = new Vector3(-i, y, -c);
                Instantiate(EndCube, V3, transform.rotation);
            }
        }
    }
}
