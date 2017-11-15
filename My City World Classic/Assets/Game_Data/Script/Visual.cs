using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Visual : MonoBehaviour {
    //方向灵敏度  
    public float sensitivityX = 5F;
    public float sensitivityY = 5F;

    //上下最大视角(Y视角)  
    public float minimumY = -90F;
    public float maximumY = 90F;

    float rotationY = 0F;

    public string Path;

    void Start()
    {
        if (!Directory.Exists(Application.dataPath + "\\Screenshot"))
        {
            Directory.CreateDirectory(Application.dataPath + "\\Screenshot");
        }
    }

    void Update()
    {
        //根据鼠标移动的快慢(增量), 获得相机左右旋转的角度(处理X)  
        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

        //根据鼠标移动的快慢(增量), 获得相机上下旋转的角度(处理Y)  
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        //角度限制. rotationY小于min,返回min. 大于max,返回max. 否则返回value   
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        //总体设置一下相机角度  
        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        if (Input.GetKey(KeyCode.F2))
        {
            Path = Application.dataPath + "\\Screenshot\\";
            StartCoroutine(CaptureByCamera(Camera.main, new Rect(0, 0, Screen.width,Screen.height ), Path + DateTime.Now.ToString("yyyy年MM月dd日HH时mm分ss秒") + ".jpg"));
            print("截图:" + DateTime.Now.ToString("yyyy年MM月dd日HH:mm:ss"));
        }
    }
    private IEnumerator CaptureByCamera(Camera mCamera, Rect mRect, string mFileName)
    {
        //等待渲染线程结束  
        yield return new WaitForEndOfFrame();

        //初始化RenderTexture  
        RenderTexture mRender = new RenderTexture((int)mRect.width, (int)mRect.height, 0);
        //设置相机的渲染目标  
        mCamera.targetTexture = mRender;
        //开始渲染  
        mCamera.Render();

        //激活渲染贴图读取信息  
        RenderTexture.active = mRender;

        Texture2D mTexture = new Texture2D((int)mRect.width, (int)mRect.height, TextureFormat.RGB24, false);
        //读取屏幕像素信息并存储为纹理数据  
        mTexture.ReadPixels(mRect, 0, 0);
        //应用  
        mTexture.Apply();

        //释放相机，销毁渲染贴图  
        mCamera.targetTexture = null;
        RenderTexture.active = null;
        GameObject.Destroy(mRender);

        //将图片信息编码为字节信息  
        byte[] bytes = mTexture.EncodeToJPG();
        //保存  
        System.IO.File.WriteAllBytes(mFileName, bytes); 
    }
}
