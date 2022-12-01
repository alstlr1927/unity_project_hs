using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PinchZoom : MonoBehaviour
{
    public float zoomSpeed = 0.5f;

    private float preDistance;

    private Vector3 baseSize = Vector3.one;
    private Vector3 basePosition = Vector3.zero;

    private float zoomFactor = 1.0f;
    
    public Camera zoomCamera;

    //Vector2 clickPoint;

    private void Start()
    {
    }
    private void OnEnable()
    {
        print("Awake");
        if (baseSize == Vector3.one)
        {
            baseSize = transform.localScale;
        }
        else
        {
            transform.localScale = baseSize;
        }
        if (basePosition == Vector3.zero)
        {
            basePosition = transform.localPosition;
        }
        else
        {
            transform.localPosition = basePosition;
        }

        zoomFactor = 1.0f;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);
            float currentDistance = Vector2.Distance(touchZero.position, touchOne.position);

            if (preDistance == 0)
            {
                preDistance = currentDistance;
                return;
            }

            print("currentDistance: " + currentDistance);
            float deltaDistance = currentDistance - preDistance;
            print("deltaDistance : " + deltaDistance);

            zoomFactor += deltaDistance * zoomSpeed;

            if (zoomFactor < 1.0f)
            {
                zoomFactor = 1.0f;
            }
            else if (zoomFactor > 5.0f)
            {
                zoomFactor = 5.0f;
            }

            transform.localScale = baseSize * zoomFactor;


            preDistance = currentDistance;

        }
        else if (Input.touchCount == 1)
        {
            
           // move camera
            // Touch touchZero = Input.GetTouch(0);
            // if (touchZero.phase == TouchPhase.Moved)
            // {
            //     Vector2 touchDeltaPosition = touchZero.deltaPosition;
            //     transform.Translate(-touchDeltaPosition.x * zoomSpeed, -touchDeltaPosition.y * zoomSpeed, 0);
            // }
        }
        else if (Input.touchCount == 0)
        {
            preDistance = 0;
        }

        if (Input.GetMouseButton(0)) {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zoomCamera.WorldToScreenPoint(transform.position).z);
            Vector3 worldPosition = zoomCamera.ScreenToWorldPoint(position);
            transform.position = worldPosition;
        }
    }

    // void OnMouseDrag() {
    //     Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zoomCamera.WorldToScreenPoint(transform.position).z);
    //     Vector3 worldPosition = zoomCamera.ScreenToWorldPoint(position);
    //     transform.position = worldPosition;
    // }
}
