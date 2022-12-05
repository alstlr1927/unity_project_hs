using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class KORManager : MonoBehaviour
{
    static int bookNum = 0;
    bool isWholeOpen = false;
    bool isGuideOpen = false;
    int guideNum = 1;

    private float curTimer = 0.0f;
    public float autoTimer = 600.0f;

    GameObject one, two, three, four, five, six;
    GameObject select, index, share, whole, next, prev;
    GameObject selectText, indexText, shareText, wholeText, nextText, prevText;

    // Start is called before the first frame update
    void Start()
    {
        one = GameObject.Find("ProjectManager").transform.Find("Guide").transform.Find("One").gameObject;
        two = GameObject.Find("ProjectManager").transform.Find("Guide").transform.Find("Two").gameObject;
        three = GameObject.Find("ProjectManager").transform.Find("Guide").transform.Find("Three").gameObject;
        four = GameObject.Find("ProjectManager").transform.Find("Guide").transform.Find("Four").gameObject;
        five = GameObject.Find("ProjectManager").transform.Find("Guide").transform.Find("Five").gameObject;
        six = GameObject.Find("ProjectManager").transform.Find("Guide").transform.Find("Six").gameObject;

        select = GameObject.Find("ProjectManager").transform.Find("Guide").transform.Find("SelectTouchIcon").gameObject;
        index = GameObject.Find("ProjectManager").transform.Find("Guide").transform.Find("IndexTouchIcon").gameObject;
        share = GameObject.Find("ProjectManager").transform.Find("Guide").transform.Find("ShareTouchIcon").gameObject;
        whole = GameObject.Find("ProjectManager").transform.Find("Guide").transform.Find("WholeTouchIcon").gameObject;
        next = GameObject.Find("ProjectManager").transform.Find("Guide").transform.Find("NextTouchIcon").gameObject;
        prev = GameObject.Find("ProjectManager").transform.Find("Guide").transform.Find("PrevTouchIcon").gameObject;

        selectText = GameObject.Find("ProjectManager").transform.Find("Guide").transform.Find("SelectBookGuideText").gameObject;
        indexText = GameObject.Find("ProjectManager").transform.Find("Guide").transform.Find("SelectIndexGuideText").gameObject;
        shareText = GameObject.Find("ProjectManager").transform.Find("Guide").transform.Find("SharePageGuideText").gameObject;
        wholeText = GameObject.Find("ProjectManager").transform.Find("Guide").transform.Find("WholePageGuideText").gameObject;
        nextText = GameObject.Find("ProjectManager").transform.Find("Guide").transform.Find("NextGuideText").gameObject;
        prevText = GameObject.Find("ProjectManager").transform.Find("Guide").transform.Find("PrevGuideText").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        curTimer += Time.deltaTime;
        if (curTimer >= autoTimer) {
            Debug.Log("timer out");
            curTimer = 0.0f;
            SceneManager.LoadScene("SelectLanguage");
        }
    }

    public void ResetTimer() {
        curTimer = 0.0f;
    }

    public void touchTest() {
        Debug.Log("touch");
    }

    public void SetBookNum(int num) {
        bookNum = num;
    }

    public int GetBookNum() {
        return bookNum;
    }

    public void CloseWholePage() {
        GameObject book1 = GameObject.Find("ProjectManager").transform.Find("WholeBook1").gameObject;
        GameObject book2 = GameObject.Find("ProjectManager").transform.Find("WholeBook2").gameObject;
        GameObject book3 = GameObject.Find("ProjectManager").transform.Find("WholeBook3").gameObject;
        book1.SetActive(false);
        book2.SetActive(false);
        book3.SetActive(false);
        isWholeOpen = false;
    }

    public void OpenWholePage() {
        if (!isWholeOpen) {
            if (bookNum == 0) {
                GameObject book = GameObject.Find("ProjectManager").transform.Find("WholeBook1").gameObject;
                book.SetActive(true);
                isWholeOpen = true;
            } else if (bookNum == 1) {
                GameObject book = GameObject.Find("ProjectManager").transform.Find("WholeBook2").gameObject;
                book.SetActive(true);
                isWholeOpen = true;
            } else if (bookNum == 2) {
                GameObject book = GameObject.Find("ProjectManager").transform.Find("WholeBook3").gameObject;
                book.SetActive(true);
                isWholeOpen = true;
            }
        } else {
            if (bookNum == 0) {
                GameObject book = GameObject.Find("ProjectManager").transform.Find("WholeBook1").gameObject;
                book.SetActive(false);
                isWholeOpen = false;
            } else if (bookNum == 1) {
                GameObject book = GameObject.Find("ProjectManager").transform.Find("WholeBook2").gameObject;
                book.SetActive(false);
                isWholeOpen = false;
            } else if (bookNum == 2) {
                GameObject book = GameObject.Find("ProjectManager").transform.Find("WholeBook3").gameObject;
                book.SetActive(false);
                isWholeOpen = false;
            }
        }
        
    }

    public void onOffGuide() {
        if (isGuideOpen) {
            GameObject guide = GameObject.Find("ProjectManager").transform.Find("Guide").gameObject;
            guide.SetActive(false);
            isGuideOpen = false;
        } else {
            GameObject guide = GameObject.Find("ProjectManager").transform.Find("Guide").gameObject;
            guide.SetActive(true);
            isGuideOpen = true;
            guideNum = 1;
            SetGuideNum(1);
        }
    }

    public void ClickNextGuideBtn() {
        if (guideNum != 6) {
            guideNum++;
            SetGuideNum(guideNum);
        }
    }

    public void ClickPrevGuideBtn() {
        if (guideNum != 1) {
            guideNum--;
            SetGuideNum(guideNum);
        }
    }

    public void SetGuideNum(int num) {
        switch (num) {
            case 1:
                one.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/select_one.png");
                two.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/unselect_two.png");
                three.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/unselect_three.png");
                four.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/unselect_four.png");
                five.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/unselect_five.png");
                six.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/unselect_six.png");

                select.SetActive(true);
                selectText.SetActive(true);
                index.SetActive(false);
                indexText.SetActive(false);
                share.SetActive(false);
                shareText.SetActive(false);
                whole.SetActive(false);
                wholeText.SetActive(false);
                next.SetActive(false);
                nextText.SetActive(false);
                prev.SetActive(false);
                prevText.SetActive(false);
                break;
            case 2:
                one.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/unselect_one.png");
                two.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/select_two.png");
                three.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/unselect_three.png");
                four.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/unselect_four.png");
                five.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/unselect_five.png");
                six.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/unselect_six.png");

                select.SetActive(false);
                selectText.SetActive(false);
                index.SetActive(true);
                indexText.SetActive(true);
                share.SetActive(false);
                shareText.SetActive(false);
                whole.SetActive(false);
                wholeText.SetActive(false);
                next.SetActive(false);
                nextText.SetActive(false);
                prev.SetActive(false);
                prevText.SetActive(false);
                break;
            case 3:
                one.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/unselect_one.png");
                two.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/unselect_two.png");
                three.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/select_three.png");
                four.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/unselect_four.png");
                five.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/unselect_five.png");
                six.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/unselect_six.png");

                select.SetActive(false);
                selectText.SetActive(false);
                index.SetActive(false);
                indexText.SetActive(false);
                share.SetActive(true);
                shareText.SetActive(true);
                whole.SetActive(false);
                wholeText.SetActive(false);
                next.SetActive(false);
                nextText.SetActive(false);
                prev.SetActive(false);
                prevText.SetActive(false);
                break;
            case 4:
                one.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/unselect_one.png");
                two.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/unselect_two.png");
                three.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/unselect_three.png");
                four.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/select_four.png");
                five.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/unselect_five.png");
                six.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/unselect_six.png");

                select.SetActive(false);
                selectText.SetActive(false);
                index.SetActive(false);
                indexText.SetActive(false);
                share.SetActive(false);
                shareText.SetActive(false);
                whole.SetActive(true);
                wholeText.SetActive(true);
                next.SetActive(false);
                nextText.SetActive(false);
                prev.SetActive(false);
                prevText.SetActive(false);
                break;
            case 5:
                one.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/unselect_one.png");
                two.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/unselect_two.png");
                three.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/unselect_three.png");
                four.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/unselect_four.png");
                five.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/select_five.png");
                six.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/unselect_six.png");

                select.SetActive(false);
                selectText.SetActive(false);
                index.SetActive(false);
                indexText.SetActive(false);
                share.SetActive(false);
                shareText.SetActive(false);
                whole.SetActive(false);
                wholeText.SetActive(false);
                next.SetActive(true);
                nextText.SetActive(true);
                prev.SetActive(false);
                prevText.SetActive(false);
                break;
            case 6:
                one.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/unselect_one.png");
                two.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/unselect_two.png");
                three.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/unselect_three.png");
                four.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/unselect_four.png");
                five.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/unselect_five.png");
                six.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/select_six.png");

                select.SetActive(false);
                selectText.SetActive(false);
                index.SetActive(false);
                indexText.SetActive(false);
                share.SetActive(false);
                shareText.SetActive(false);
                whole.SetActive(false);
                wholeText.SetActive(false);
                next.SetActive(false);
                nextText.SetActive(false);
                prev.SetActive(true);
                prevText.SetActive(true);
                break;
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
