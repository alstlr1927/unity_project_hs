using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WholePage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHide() {
        gameObject.SetActive(false);
    } 

    public void SetView() {
        gameObject.SetActive(true);
    } 
}
