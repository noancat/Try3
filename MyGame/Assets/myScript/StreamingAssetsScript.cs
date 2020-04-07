using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class StreamingAssetsScript : MonoBehaviour
{
    string folderPath;
    string[] filePaths;

    int n;

    private void Awake()
    {
        ImageLoader();
    }

    void ImageLoader()
    {

        folderPath = Application.streamingAssetsPath + "/SAsprite/";
        filePaths = Directory.GetFiles(folderPath, "*.jpg");

        byte[] pngBytes = System.IO.File.ReadAllBytes(filePaths[n]);

        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(pngBytes);

        Sprite fromTex = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);

        GetComponent<SpriteRenderer>().sprite = fromTex;
    }
}

