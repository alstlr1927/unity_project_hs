using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureIcon : MonoBehaviour
{
    public GameObject bookTap;
    public GameObject mapDoubleTap; // map
    public GameObject bookFlip;
    public GameObject mapMove; // map
    public GameObject mapPinch; // map
    public GameObject bookLong;

    float curTimer = 0.0f;
    public float autoTimer = 30.0f;
    int gestureIdx = 0;
    bool isMap = false;

    List<GameObject> mapGestureList = new List<GameObject>();
    List<GameObject> bookGestureList = new List<GameObject>();


    // float curBookTapTime = 0.0f;
    // float curMapDoubleTapTime = 0.0f;
    // float curBookFlipTime = 0.0f;
    // float curMapMoveTime = 0.0f;
    // float curMapPinchTime = 0.0f;
    // float curBookLongTime = 0.0f;

    // public float autoBookTapTime = 30.0f;
    // public float autoMapDoubleTapTime = 30.0f;
    // public float autoBookFlipTime = 30.0f;
    // public float autoMapMoveTime = 30.0f;
    // public float autoMapPinchTime = 30.0f;
    // public float autoBookLongTime = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        mapGestureList.Add(mapDoubleTap);
        mapGestureList.Add(mapMove);
        mapGestureList.Add(mapPinch);

        bookGestureList.Add(bookTap);
        bookGestureList.Add(bookFlip);
        bookGestureList.Add(bookLong);
    }

    // Update is called once per frame
    void Update()
    {
        curTimer += Time.deltaTime;
        //Debug.Log("curTimer: " + curTimer);
        if (curTimer >= autoTimer) {
            // gesture active
            setGestureActive();
            if (curTimer >= autoTimer + 10.0f) {
                // gesture deactive
                setGestureDeactive();
                curTimer = 0.0f;
                if (gestureIdx >= 2) {
                    gestureIdx = 0;
                } else {
                    gestureIdx++;
                }
            }
        }

        // curBookFlipTime += Time.deltaTime;
        // if (curBookFlipTime >= autoBookFlipTime) {
        //     bookFlip.SetActive(true);
        //     if (curBookFlipTime >= autoBookFlipTime + 10.0f) {
        //         bookFlip.SetActive(false);
        //         curBookFlipTime = 0.0f;
        //     }
        // }

        // curMapDoubleTapTime += Time.deltaTime;
        // if (curMapDoubleTapTime >= autoMapDoubleTapTime) {
        //     bookFlip.SetActive(true);
        //     if (curMapDoubleTapTime >= autoMapDoubleTapTime + 10.0f) {
        //         bookFlip.SetActive(false);
        //         curBookFlipTime = 0.0f;
        //     }
        // }
    }

    public void setGestureActive() {
        if (isMap) {
            for (int i = 0; i < mapGestureList.Count;i++) {
                if (i == gestureIdx) {
                    mapGestureList[i].SetActive(true);
                } else {
                    mapGestureList[i].SetActive(false);
                }
            }
        } else {
            for (int i = 0;i < bookGestureList.Count;i++) {
                if (i == gestureIdx) {
                    bookGestureList[i].SetActive(true);
                } else {
                    bookGestureList[i].SetActive(false);
                }
            }
        }
    }

    public void setGestureDeactive() {
        if (isMap) {
            mapGestureList[gestureIdx].SetActive(false);
        } else {
            bookGestureList[gestureIdx].SetActive(false);
        }
    }

    public void setMap(bool flag) {
        if (isMap != flag) {
            isMap = flag;
            mapGestureList[gestureIdx].SetActive(false);
            bookGestureList[gestureIdx].SetActive(false);
            curTimer = 0.0f;
            gestureIdx = 0;
        } else {
            return;
        }
    }
}
