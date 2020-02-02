using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{

    SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }


     IEnumerator FadeOutt()
    {

        for(float f= 1;f >=-0.05; f-=0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.001f);
        }
    }

   public void startFadeout()
    {
        StartCoroutine("FadeOutt");
    }

}
