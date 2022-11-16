using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System;

public class ShareManager : MonoBehaviour
{
    GameObject sharePanel;
    private const string SENDER_EMAIL = "krwarmap@gmail.com";
    private const string SENDER_PASSWORD = "wisfxvdhxdldrmjv";
    

    // Start is called before the first frame update
    void Start()
    {
        sharePanel = GameObject.Find("ShareManager").transform.Find("SharePanel").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onSharePanel() {
        sharePanel.SetActive(true);
    }

    public void offSharePanel() {
        sharePanel.SetActive(false);
    }

    public void getCurrentImage() {
        GameObject image = GameObject.Find("Canvas").transform.Find("Book01").transform.Find("RightNext").gameObject;
        Debug.Log("dddd" + image.GetComponent<UnityEngine.UI.Image>().sprite.name);
    }

    public void SendEmailFunc() {
        string email = "dnalstlr1927@icloud.com";
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(SENDER_EMAIL);
        mail.To.Add(email);
        mail.Subject = "정전협정문";
        mail.Body = "전쟁기념관 정전협정문 공유메일";

        Attachment attachment = new Attachment(Application.streamingAssetsPath + "/menu_sub_01_on.png");
        mail.Attachments.Add(attachment);

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
            Debug.Log("success");
        }
        catch (Exception e)
        {
            Debug.Log(e);
            
        }
    }
}
