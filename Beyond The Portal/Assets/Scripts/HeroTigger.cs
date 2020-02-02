using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroTigger : MonoBehaviour
{
    public hero _hero;
    void OnTriggerEnter2D(Collider2D collider)
    {
        //hit = true;

        if (collider.tag == "enemyBlock")
        {
        _hero.hit = true;
            Debug.Log("keseeeeeeeeb :D");
        }
        else
        {
            Debug.Log(collider.tag);
        } 
    }
}
