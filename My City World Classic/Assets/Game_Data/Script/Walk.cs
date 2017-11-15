using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Walk : MonoBehaviour {

    Vector3 JA;
    Vector3 JB;
    Vector3 C = new Vector3(0, 1, 0);
    public GameObject Visual;
    bool B,H;

    void FixedUpdate()
    {
        XinZ();
        Cursorvisible();
    }

    void XinZ()
    {
        JA = Visual.transform.forward;
        JB = Visual.transform.right;
        JA.y = 0f;
        JB.y = 0f;
        C.x = 0;
        C.z = 0;
        // Move forward or backward
        if (Input.GetKey(KeyCode.W))
            transform.position += Vector3.ClampMagnitude(JA, 0.1f);
        else if (Input.GetKey(KeyCode.S))
            transform.position -= Vector3.ClampMagnitude(JA, 0.1f);

        // Move left or right
        if (Input.GetKey(KeyCode.A))
            transform.position -= Vector3.ClampMagnitude(JB, 0.1f);
        else if (Input.GetKey(KeyCode.D))
            transform.position += Vector3.ClampMagnitude(JB, 0.1f);

        // Move up or down
        if (Input.GetKey(KeyCode.Space))
            transform.position += Vector3.ClampMagnitude(C, 0.1f);
        else if (Input.GetKey(KeyCode.LeftShift))
            transform.position -= Vector3.ClampMagnitude(C, 0.1f);

    }
    void Cursorvisible()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            B = true;
        }
        else if (B == true & Input.GetMouseButtonDown(0))
        {
            B = false;
        }
        Cursor.visible = B;
        if (!H & Input.GetKey(KeyCode.F1))
        {
            H = true;
        }
        else if (H & Input.GetKey(KeyCode.F1))
        {
            H = false;
        }
        GetComponent<Rigidbody>().useGravity = H;
    }
}
