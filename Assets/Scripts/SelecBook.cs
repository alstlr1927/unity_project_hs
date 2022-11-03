using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelecBook : MonoBehaviour
{
    public bool isSelect = false;

    public enum BookType
    {
        Book1,
        Book2,
        Book3,
    }

    public BookType bookType;

    // Start is called before the first frame update
    void Start()
    {
        SetImage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSelect() {
        if (!isSelect) {
            isSelect = !isSelect;
            SetImage();
        }
        return;
    }

    public void SetUnSelect() {
        isSelect = false;
        SetImage();
    }

    public void SetImage() {
        if (!isSelect) {
            switch (bookType) {
                case BookType.Book1:
                    GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/menu_sub_01_off.png");
                    break;
                case BookType.Book2:
                    GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/menu_sub_02_off.png");
                    break;
                case BookType.Book3:
                    GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/menu_sub_03_off.png");
                    break;
            }
        } else {
            switch (bookType) {
                case BookType.Book1:
                    GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/menu_sub_01_on.png");
                    break;
                case BookType.Book2:
                    GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/menu_sub_02_on.png");
                    break;
                case BookType.Book3:
                    GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/menu_sub_03_on.png");
                    break;
            }
        } 
    }

    public Sprite GetSpritefromImage(string imgPath) {
        try {
            //Converts desired path into byte array
            byte[] pngBytes = System.IO.File.ReadAllBytes(imgPath);

            //Creates texture and loads byte array data to create image
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(pngBytes);

            //Creates a new Sprite based on the Texture2D
            Sprite fromTex = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);

            return fromTex;
        } catch (System.Exception) {
            throw;
        }
    }
}
