using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedFollower : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject selectedFollower;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(selectedFollower != null) {
            transform.position = selectedFollower.transform.position;
        }
    }

    public void setSelectedFollower(GameObject follower) {
        selectedFollower = follower;
    }
}
