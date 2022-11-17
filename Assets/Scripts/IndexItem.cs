using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickItem() {
        GameObject indicator = gameObject.transform.Find("Indicator").gameObject;
        indicator.SetActive(true);
    }
}
