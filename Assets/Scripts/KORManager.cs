using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KORManager : MonoBehaviour
{
    static int bookNum = 0;
    bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        isOpen = false;
    }

    public void OpenWholePage() {
        if (!isOpen) {
            if (bookNum == 0) {
                GameObject book = GameObject.Find("ProjectManager").transform.Find("WholeBook1").gameObject;
                book.SetActive(true);
                isOpen = true;
            } else if (bookNum == 1) {
                GameObject book = GameObject.Find("ProjectManager").transform.Find("WholeBook2").gameObject;
                book.SetActive(true);
                isOpen = true;
            } else if (bookNum == 2) {
                GameObject book = GameObject.Find("ProjectManager").transform.Find("WholeBook3").gameObject;
                book.SetActive(true);
                isOpen = true;
            }
        } else {
            if (bookNum == 0) {
                GameObject book = GameObject.Find("ProjectManager").transform.Find("WholeBook1").gameObject;
                book.SetActive(false);
                isOpen = false;
            } else if (bookNum == 1) {
                GameObject book = GameObject.Find("ProjectManager").transform.Find("WholeBook2").gameObject;
                book.SetActive(false);
                isOpen = false;
            } else if (bookNum == 2) {
                GameObject book = GameObject.Find("ProjectManager").transform.Find("WholeBook3").gameObject;
                book.SetActive(false);
                isOpen = false;
            }
        }
        
    }
}
