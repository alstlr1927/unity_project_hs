using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLang : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickKorBtn() {
        SceneManager.LoadScene("KoreanVer");
    }

    // public void ClickCHNBtn() {
    //     SceneManager.LoadScene("ChineseVer");
    // }

    // public void ClickENGBtn() {
    //     SceneManager.LoadScene("EnglishVer");
    // }
}
