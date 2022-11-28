using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class TotalManager : MonoBehaviour
{
    public static TotalManager instance;

    public AudioClip bookCatch;
    public AudioClip bookDrop;
    public AudioClip bookOpen;

    public static Process osk;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
