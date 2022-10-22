using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollView : MonoBehaviour
{
    List<string> indexList;

    // Start is called before the first frame update
    void Start()
    {
        CreateListItem();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CreateListItem() {
    }

    public void SetHide() {
        gameObject.SetActive(false);
    }

    public void SetView() {
        gameObject.SetActive(true);
    }
}
