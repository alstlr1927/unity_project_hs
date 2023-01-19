using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sceneChangeAnimation : MonoBehaviour
{
    public Sprite[] sprites;
    public float fps = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            GetComponent<Image>().sprite = sprites[i];
            yield return new WaitForSeconds(1f / fps);
        }

        // opacity down after the animation is done
        for (float f = 1f; f >= 0; f -= 0.1f)
        {
            if(0.1f > f)
            {
                f = 0;
            }
            Color c = GetComponent<Image>().color;
            c.a = f;
            GetComponent<Image>().color = c;
            yield return new WaitForSeconds(1f / fps);
        }

        // destroy the object after the animation is done
        Destroy(gameObject);

        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
