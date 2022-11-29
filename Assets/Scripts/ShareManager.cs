using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System;
using System.Threading;

public class ShareManager : MonoBehaviour
{
    GameObject sharePanel;
    string DROPDOWN_KEY = "DROPDOWN_KEY";

    private const string SENDER_EMAIL = "krwarmap@gmail.com";
    private const string SENDER_PASSWORD = "wisfxvdhxdldrmjv";
    public string bookVer = "";
    string imageName = "";
    string domain = "daum.net";
    int bookNum = 0;
    public GameObject textArea;
    public GameObject domainArea;
    List<string> optionList = new List<string>();
    int currentOption = 0;
    GameObject loadingPanel;
    int option = 0;
    string emailAddress = "";

    // Start is called before the first frame update
    void Start()
    {
        sharePanel = GameObject.Find("ShareManager").transform.Find("SharePanel").gameObject;
        loadingPanel = GameObject.Find("LoadingManager").transform.Find("LoadingPanel").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            ConfirmButtomTouchedFunc();
        }
    }

    public void setBookNum(int num) {
        bookNum = num;
    }

    public void onSharePanel() {
        textArea.GetComponent<TMPro.TMP_InputField>().text = "";
        domainArea.GetComponent<TMPro.TMP_InputField>().text = "";
        sharePanel.SetActive(true);
    }

    public void resetEmail() {
        textArea.GetComponent<TMPro.TMP_InputField>().text = "";
        domainArea.GetComponent<TMPro.TMP_InputField>().text = "";
    }

    public void offSharePanel() {
        CloseKeyboard();
        textArea.GetComponent<TMPro.TMP_InputField>().text = "";
        domainArea.GetComponent<TMPro.TMP_InputField>().text = "";
        sharePanel.SetActive(false);
    }

    public void getCurrentImage() {
        Debug.Log("book num" + bookNum);
        if (bookNum == 0) {
            GameObject image = GameObject.Find("Canvas").transform.Find("Book01").transform.Find("RightNext").gameObject;
            Debug.Log("dddd" + image.GetComponent<UnityEngine.UI.Image>().sprite.name);
            imageName = image.GetComponent<UnityEngine.UI.Image>().sprite.name;
        } else if (bookNum == 1) {
            GameObject image = GameObject.Find("Canvas").transform.Find("Book02").transform.Find("RightNext").gameObject;
            Debug.Log("dddd" + image.GetComponent<UnityEngine.UI.Image>().sprite.name);
            imageName = image.GetComponent<UnityEngine.UI.Image>().sprite.name;
        } else if (bookNum == 2) {
            GameObject image = GameObject.Find("Canvas").transform.Find("Book03").transform.Find("RightNext").gameObject;
            Debug.Log("dddd" + image.GetComponent<UnityEngine.UI.Image>().sprite.name);
            imageName = image.GetComponent<UnityEngine.UI.Image>().sprite.name;
        }
    }

    public void ConfirmButtomTouchedFunc() {
        string email = "";
        int option = PlayerPrefs.GetInt(DROPDOWN_KEY);
        Debug.Log("option : " + option);
        if (option == 5) {
            email = textArea.GetComponent<TMPro.TMP_InputField>().text + "@" + domainArea.GetComponent<TMPro.TMP_InputField>().text;
        } else {
            if (option == 0) {
                email = textArea.GetComponent<TMPro.TMP_InputField>().text + "@daum.net";
            } else if (option == 1) {
                email = textArea.GetComponent<TMPro.TMP_InputField>().text + "@gmail.com";
            } else if (option == 2) {
                email = textArea.GetComponent<TMPro.TMP_InputField>().text + "@hanmail.net";
            } else if (option == 3) {
                email = textArea.GetComponent<TMPro.TMP_InputField>().text + "@naver.com";
            } else if (option == 4) {
                email = textArea.GetComponent<TMPro.TMP_InputField>().text + "@nate.com";
            }
        }
        Debug.Log(email);
        
        if (email.Length != 0) {
            if (!Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")) {
                Debug.Log("이메일 형식이 아닙니다.");
                return;
            } else {
                SendEmail();
            }
        } else {
            Debug.Log("이메일을 입력해주세요.");
        }
    }

    public void SendEmail() {
        option = PlayerPrefs.GetInt(DROPDOWN_KEY);
        if (option == 5) {
            emailAddress = textArea.GetComponent<TMPro.TMP_InputField>().text + "@" + domainArea.GetComponent<TMPro.TMP_InputField>().text;
        } else {
            if (option == 0) {
                emailAddress = textArea.GetComponent<TMPro.TMP_InputField>().text + "@daum.net";
            } else if (option == 1) {
                emailAddress = textArea.GetComponent<TMPro.TMP_InputField>().text + "@gmail.com";
            } else if (option == 2) {
                emailAddress = textArea.GetComponent<TMPro.TMP_InputField>().text + "@hanmail.net";
            } else if (option == 3) {
                emailAddress = textArea.GetComponent<TMPro.TMP_InputField>().text + "@naver.com";
            } else if (option == 4) {
                emailAddress = textArea.GetComponent<TMPro.TMP_InputField>().text + "@nate.com";
            }
        }
        loadingPanel.SetActive(true);
        Thread thread = new Thread(new ThreadStart(SendEmailFunc));
        thread.Start();

        Invoke("closeLoading", 10f);
        //Invoke("SendEmailFunc", 0.5f);
    }

    public void closeLoading() {
        loadingPanel.SetActive(false);
        offSharePanel();
    }

    public void SendEmailFunc() {
        //string email = "";
        Debug.Log("option : " + option);
        // if (option == 5) {
        //     email = textArea.GetComponent<TMPro.TMP_InputField>().text + "@" + domainArea.GetComponent<TMPro.TMP_InputField>().text;
        // } else {
        //     if (option == 0) {
        //         email = textArea.GetComponent<TMPro.TMP_InputField>().text + "@daum.net";
        //     } else if (option == 1) {
        //         email = textArea.GetComponent<TMPro.TMP_InputField>().text + "@gmail.com";
        //     } else if (option == 2) {
        //         email = textArea.GetComponent<TMPro.TMP_InputField>().text + "@hanmail.net";
        //     } else if (option == 3) {
        //         email = textArea.GetComponent<TMPro.TMP_InputField>().text + "@naver.com";
        //     } else if (option == 4) {
        //         email = textArea.GetComponent<TMPro.TMP_InputField>().text + "@nate.com";
        //     }
        // }
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(SENDER_EMAIL);
        mail.To.Add(emailAddress);
        mail.Subject = "정전협정문";
        mail.Body = "다운로드 링크 (download link) : https://drive.google.com/drive/folders/1lUFW_foL2TU1iNZ0mOjhKUnjgh5Y6qsP?usp=sharing";

        Debug.Log("attach start");
        Attachment attachment = new Attachment(Application.persistentDataPath + "/" + imageName + ".png");
        mail.Attachments.Add(attachment);
        // if (bookVer == "KOR") {
        //     if (bookNum == 0) {
        //         Attachment attachment = new Attachment(Application.streamingAssetsPath + "/BookImage/MainBook/KOR/" + imageName + ".png");
        //         mail.Attachments.Add(attachment);
        //     } else if (bookNum == 1) {
        //         Attachment attachment = new Attachment(Application.streamingAssetsPath + "/BookImage/ExtraBook/KOR/" + imageName + ".png");
        //         mail.Attachments.Add(attachment);
        //     } else if (bookNum == 2) {
        //         Attachment attachment = new Attachment(Application.streamingAssetsPath + "/BookImage/MapBook/KOR/" + imageName + ".png");
        //         mail.Attachments.Add(attachment);
        //     } else {
        //         return;
        //     }
        // } else if (bookVer == "ENG") {
        //     if (bookNum == 0) {
        //         Attachment attachment = new Attachment(Application.streamingAssetsPath + "/BookImage/MainBook/ENG/" + imageName + ".png");
        //         mail.Attachments.Add(attachment);
        //     } else if (bookNum == 1) {
        //         Attachment attachment = new Attachment(Application.streamingAssetsPath + "/BookImage/ExtraBook/ENG/" + imageName + ".png");
        //         mail.Attachments.Add(attachment);
        //     } else if (bookNum == 2) {
        //         Attachment attachment = new Attachment(Application.streamingAssetsPath + "/BookImage/MapBook/ENG/" + imageName + ".png");
        //         mail.Attachments.Add(attachment);
        //     } else {
        //         return;
        //     }
        // } else if (bookVer == "CHN") {
        //     if (bookNum == 0) {
        //         Attachment attachment = new Attachment(Application.streamingAssetsPath + "/BookImage/MainBook/CHN/" + imageName + ".png");
        //         mail.Attachments.Add(attachment);
        //     } else if (bookNum == 1) {
        //         Attachment attachment = new Attachment(Application.streamingAssetsPath + "/BookImage/ExtraBook/CHN/" + imageName + ".png");
        //         mail.Attachments.Add(attachment);
        //     } else if (bookNum == 2) {
        //         Attachment attachment = new Attachment(Application.streamingAssetsPath + "/BookImage/MapBook/CHN/" + imageName + ".png");
        //         mail.Attachments.Add(attachment);
        //     } else {
        //         return;
        //     }
        // }

        Debug.Log("attach end");
        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 587;
        smtpServer.Credentials = new System.Net.NetworkCredential(SENDER_EMAIL, SENDER_PASSWORD) as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback = 
            delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) 
            { return true; };

        try
        {
            smtpServer.Send(mail);
            // loadingPanel.SetActive(false);
            //offSharePanel();
            Debug.Log("success");
        }
        catch (Exception e)
        {
            // loadingPanel.SetActive(false);
            // offSharePanel();
            Debug.Log(e);
        }
    }

    public void OnEmailInputAreaTouched() {
        OnInputTouch();
    }

    public void OnInputTouch() {
        TotalManager.osk = System.Diagnostics.Process.Start("osk.exe");
    }

    public void CloseKeyboard() {
        if (TotalManager.osk != null) {
            TotalManager.osk.Kill();
            TotalManager.osk = null;
        }
    }

    public void onValueChanged(int value) {
        Debug.Log("value" + value);
    }
}
