using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMapPage : MonoBehaviour
{
    public GameObject mapManager;

    public float doubleClickSecond = 0.25f;
    private bool isOneClick = false;
    private double timer = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isOneClick && ((Time.time - timer) > doubleClickSecond)) {
            isOneClick = false;
        }

        if (Input.GetMouseButtonDown(0)) {
            if (!isOneClick) {
                timer = Time.time;
                isOneClick = true;
            } else if (isOneClick && ((Time.time - timer) < doubleClickSecond)) {
                isOneClick = false;
                mapManager.GetComponent<MapManager>().setImage();
                mapManager.GetComponent<MapManager>().SetView();
                Debug.Log("double click");
            }
        }   
    }
}
