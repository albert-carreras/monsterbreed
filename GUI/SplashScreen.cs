using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour
{


    void Start()
    {
        SaveLoad.Load();

    }

    void OnGUI()
    {
        Texture2D texture = Resources.Load("load", typeof(Texture2D)) as Texture2D;
        GUI.DrawTexture (new Rect(0, 0, 640, 480), texture);
        if (Input.GetKeyDown("space"))
        {
            Application.LoadLevel("Main");
        }

    }
}
