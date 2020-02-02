using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hero : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 2.0f;
    public Bridge2 b2;
    public bridge b;
   // [SerializeField] private GameObject br= null;
    public bool hit = false;
    bool create = false;

    public GameObject brick;
   // public CharacterController2D controller2D ;

    public Transform position;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //if(controller2D.BlocksCount!=0)
            //{
                if (hit)
                {
                    //walk

                }
                else
                {
                    //create 
                    if (create == false)
                        StartCoroutine(Build());
                    else
                    {
                        Debug.Log("can't Build");

                    }
                }
            //}
            
            
        }
        int childrenCount = b.transform.childCount;
        int childrenCount2 = b2.transform.childCount;
        //if (b.transform.GetChild(childrenCount - 1).position.x >= b2.transform.GetChild(childrenCount2 - 1).position.x)
        //{
        //    Debug.Log("keseeeeeeeeb :D");
        //}
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        hit = false;
        //Debug.Log("Exit");
    }

    IEnumerator Build()
    {
        Debug.Log("gdwhghjwghjgedwj");
        create = true;
        yield return new WaitForSeconds(0.5f);
        Instantiate(brick, position.position, new Quaternion()).gameObject.transform.SetParent(b2.transform);

        //br.gameObject.SetActive(true);
        //yield return new WaitForSeconds(0.5f);
        //transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime);
        create = false;

    }

}
