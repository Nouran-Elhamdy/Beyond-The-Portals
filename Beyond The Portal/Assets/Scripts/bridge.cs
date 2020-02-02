using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridge : MonoBehaviour
{
    // Start is called before the first frame update
 

   public void ListOfBlock ()
    {
      

    }
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {

        Debug.Log(collider.gameObject.name);

        if (collider.CompareTag("blockHero"))
        {
            Debug.Log("keseeeeeeeeb :D");
        }
        else
        {
            Debug.Log(collider.tag);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.name);
    }
}
