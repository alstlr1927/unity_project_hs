using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectManager : MonoBehaviour
{
    public static ProjectManager instance;

    public AudioClip bookCatch;
    public AudioClip bookDrop;
    public AudioClip bookOpen;


    // Start is called before the first frame update
    void Start()
    {
       // DontDestroyOnLoad(this.gameObject);
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
