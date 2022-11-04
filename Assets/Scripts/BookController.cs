using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class BookController : MonoBehaviour, IDragHandler
{
    public GameObject book;
    public GameObject bookShadow;
    public GameObject bookbody;
    public GameObject scaleButtonKOR;
    public GameObject scaleButtonENG;
    public GameObject scaleButtonCHN;

    private Transform bookOrigTransform;
    private Transform bookTransform;
    private Vector3 defaultPos;

    //public ProjectManager projectManager;
    // Start is called before the first frame update
    void Start()
    {
        //projectManager = GameObject.Find("ProjectManager").GetComponent<ProjectManager>();
        defaultPos = book.transform.localPosition;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && Vector2.Distance(book.transform.position, scaleButtonKOR.transform.position) < 1.2)
        {
            //projectManager.scale = 0;
            SceneManager.LoadScene("KoreanVer");
            Debug.Log("KOR");
        }
        if (Input.GetMouseButtonUp(0) && Vector2.Distance(book.transform.position, scaleButtonENG.transform.position) < 1.2)
        {
            //projectManager.scale = 1;
            SceneManager.LoadScene("EnglishVer");
            Debug.Log("ENG");
        }
        if (Input.GetMouseButtonUp(0) && Vector2.Distance(book.transform.position, scaleButtonCHN.transform.position) < 1.2)
        {
            //projectManager.scale = 2;
            SceneManager.LoadScene("ChineseVer");
            Debug.Log("CHN");
        }

        // Debug.Log("KOR" + Vector2.Distance(book.transform.position, scaleButtonKOR.transform.position));
        // Debug.Log("ENG" + Vector2.Distance(book.transform.position, scaleButtonENG.transform.position));
        // Debug.Log("CHN" + Vector2.Distance(book.transform.position, scaleButtonCHN.transform.position));


        if (Input.GetMouseButton(0) == false)
        {
            book.transform.localPosition = Vector3.Lerp(book.transform.localPosition, defaultPos, Time.deltaTime * 1.2f);
            bookShadow.transform.localPosition = Vector3.Lerp(bookShadow.transform.localPosition, defaultPos, Time.deltaTime * 1.2f);
            bookbody.transform.localScale = Vector3.Lerp(bookbody.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 1.2f);
        }
        else
        {
            bookShadow.transform.localPosition = Vector3.Lerp(bookShadow.transform.localPosition, new Vector3(100, -100, 0), Time.deltaTime * 1.2f);
            bookbody.transform.localScale = Vector3.Lerp(bookbody.transform.localScale, new Vector3(1.1f, 1.1f, 1.1f), Time.deltaTime * 1.2f);
        }

        // if (Input.GetMouseButton(0) == false)
        // {
        //     book.transform.position = Vector3.Lerp(book.transform.position, new Vector3(0, 0, 0), Time.deltaTime * 2f);
        //     bookShadow.transform.localPosition = Vector3.Lerp(bookShadow.transform.localPosition, new Vector3(0, 0, 0), Time.deltaTime * 1.2f);
        //     bookbody.transform.localScale = Vector3.Lerp(bookbody.transform.localScale, new Vector3(1, 1, 1), Time.deltaTime * 1.2f);

        // }
        // else
        // {
        //     bookShadow.transform.localPosition = Vector3.Lerp(bookShadow.transform.localPosition, new Vector3(100, -100, 0), Time.deltaTime * 1.2f);
        //     bookbody.transform.localScale = Vector3.Lerp(bookbody.transform.localScale, new Vector3(1.1f, 1.1f, 1.1f), Time.deltaTime * 1.2f);
        // }
    }

    public void OnDrag(PointerEventData eventData)
    {
        book.transform.position += (Vector3)eventData.delta;

        // Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(book.transform.position).z);
        // Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
        // book.transform.position = worldPosition;             

        if (Vector2.Distance(book.transform.position, scaleButtonKOR.transform.position) < 1.2)
        {
            scaleButtonKOR.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/menu_01_on.png");
        }
        else
        {
            scaleButtonKOR.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/menu_01_off.png");
        }
        if (Vector2.Distance(book.transform.position, scaleButtonENG.transform.position) < 1.2)
        {
            scaleButtonENG.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/menu_03_on.png");
        }
        else
        {
            scaleButtonENG.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/menu_03_off.png");
        }
        if (Vector2.Distance(book.transform.position, scaleButtonCHN.transform.position) < 1.2)
        {
            scaleButtonCHN.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/menu_02_on.png");
        }
        else
        {
            scaleButtonCHN.GetComponent<UnityEngine.UI.Image>().sprite = GetSpritefromImage(Application.streamingAssetsPath + "/menu_02_off.png");
        }
    }

    public Sprite GetSpritefromImage(string imgPath)
    {
        try
        {
            //Converts desired path into byte array
            byte[] pngBytes = System.IO.File.ReadAllBytes(imgPath);

            //Creates texture and loads byte array data to create image
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(pngBytes);

            //Creates a new Sprite based on the Texture2D
            Sprite fromTex = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);

            return fromTex;
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    void OnMouseDrag()
    {
        // Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(book.transform.position).z);
        // Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
        // book.transform.position = worldPosition;             

        // if (Vector3.Distance(book.transform.position, scaleButtonKOR.transform.position) < 10)
        // {
        //     scaleButtonKOR.GetComponent<UnityEngine.UI.Image>().color = new Color(0, 96, 186);
        //     scaleButtonKOR.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255);
        // } else {
        //     scaleButtonKOR.GetComponent<UnityEngine.UI.Image>().color = Color.white;
        //     scaleButtonKOR.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.black;
        // }
        // if (Vector3.Distance(book.transform.position, scaleButtonENG.transform.position) < 10)
        // {
        //     scaleButtonENG.GetComponent<UnityEngine.UI.Image>().color = new Color(0, 96, 186);
        //     scaleButtonENG.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255);
        // } else {
        //     scaleButtonENG.GetComponent<UnityEngine.UI.Image>().color = Color.white;
        //     scaleButtonENG.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.black;
        // }

        // if (Vector3.Distance(book.transform.position, scaleButtonCHN.transform.position) < 10)
        // {
        //     scaleButtonCHN.GetComponent<UnityEngine.UI.Image>().color = new Color(0, 96, 186);
        //     scaleButtonCHN.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255);
        // } else {
        //     scaleButtonCHN.GetComponent<UnityEngine.UI.Image>().color = Color.white;
        //     scaleButtonCHN.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.black;
        // }
    }

}
