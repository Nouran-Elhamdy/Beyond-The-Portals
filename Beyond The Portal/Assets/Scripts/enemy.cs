using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 0.5f;
    public bridge b;
    public bool flag = false;
    public bool flag2 = false;
    public float positionEnemy;
    public CharacterController2D _hero;
    void Start()
    {
        positionEnemy = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //System.Threading.Thread.Sleep(500);
        int childrenCount = b.transform.childCount;
        if(childrenCount > 1&& _hero.hit==false)
        {
            if (transform.position.x < b.transform.GetChild(childrenCount - 2).position.x)
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
           
            else
            {
                Destroy(b.transform.GetChild(childrenCount - 1).gameObject, 8.0f);
                transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime);
                flag = true;
            }
        }
       
       

    }
}
