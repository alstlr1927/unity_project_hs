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

    private float moveSpeed = 0.5f;
    private Vector2 nowPos, prePos;
    private Vector3 movePos;


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
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) {
                prePos = touch.position;
            } else if (touch.phase == TouchPhase.Moved) {
                nowPos = touch.position - touch.deltaPosition;
                movePos = (Vector3)(prePos - nowPos) * Time.deltaTime * moveSpeed;
                transform.Translate(movePos);
                prePos = touch.position - touch.deltaPosition;
            }

        }
        else if (Input.touchCount == 0)
        {
            preDistance = 0;
        }
    }
}
