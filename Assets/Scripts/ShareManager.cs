using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareManager : MonoBehaviour
{
    GameObject sharePanel;
    

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
}
