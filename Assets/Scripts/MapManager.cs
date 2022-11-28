using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    string imageName = "";
    public string bookVer = "";
    public GameObject imagePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHide() {
        //gameObject.SetActive(false);
        GameObject backPanel = GameObject.Find("PopupManager").transform.Find("BackPanel").gameObject;
        GameObject closeBtn = GameObject.Find("PopupManager").transform.Find("CloseBtn").gameObject;
        backPanel.SetActive(false);
        closeBtn.SetActive(false);
    }

    public void SetView() {
        GameObject backPanel = GameObject.Find("PopupManager").transform.Find("BackPanel").gameObject;;
        GameObject closeBtn = GameObject.Find("PopupManager").transform.Find("CloseBtn").gameObject;
        backPanel.SetActive(true);
        closeBtn.SetActive(true);
    }

    public void getCurrentImage() {
        GameObject image = GameObject.Find("Canvas").transform.Find("Book03").transform.Find("RightNext").gameObject;
        Debug.Log("dddd" + image.GetComponent<UnityEngine.UI.Image>().sprite.name);
        imageName = image.GetComponent<UnityEngine.UI.Image>().sprite.name;
    }

    public void setImage() {
        getCurrentImage();
        if (bookVer == "KOR") {
            imagePanel.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/BookImage/MapBook/KOR/" + imageName + ".png");
        } else if (bookVer == "ENG") {
            imagePanel.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/BookImage/MapBook/ENG/" + imageName + ".png");
        } else if (bookVer == "CHN") {
            imagePanel.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/BookImage/MapBook/CHN/" + imageName + ".png");
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
