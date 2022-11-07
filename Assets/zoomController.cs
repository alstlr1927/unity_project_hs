using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class zoomController : MonoBehaviour
{
    int PageLayer;
    public GameObject ZoomLens;
    // Start is called before the first frame update
    void Start()
    {
        PageLayer = LayerMask.NameToLayer("Page");

    }

    // Update is called once per frame
    
    void Update()
    {

        if(Input.GetMouseButtonDown(0)) {
            if(IsPointerOverUIElement()) {
                ZoomLens.SetActive(true);
            }
        }

        if(Input.GetMouseButton(0)) {
            if(IsPointerOverUIElement()) {
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 10;
                Vector3 pos = Camera.main.ScreenToWorldPoint(mousePos);
                ZoomLens.transform.position = new Vector3(pos.x, pos.y+0.5f, transform.position.z);

            }
        }

        if(Input.GetMouseButtonUp(0)) {
            ZoomLens.SetActive(false);
        }
        
    }

    public bool IsPointerOverUIElement()
    {
        return IsPointerOverUIElement(GetEventSystemRaycastResults());
    }


    //Returns 'true' if we touched or hovering on Unity UI element.
    private bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
    {
        for (int index = 0; index < eventSystemRaysastResults.Count; index++)
        {
            RaycastResult curRaysastResult = eventSystemRaysastResults[index];
            if (curRaysastResult.gameObject.layer == PageLayer)
                return true;
        }
        return false;
    }
    static List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        return raysastResults;
    }
}
