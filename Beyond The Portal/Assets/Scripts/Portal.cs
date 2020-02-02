using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] Transform positionn;
    [SerializeField] AudioSource audio;
    //[SerializeField] private int Flag = 0;
    //[SerializeField] private Transform pos;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()
    {
        if(Vector2.Distance( this.gameObject.transform.position , GameObject.FindGameObjectWithTag("Player").transform.position) < 0.3f)
            StartCoroutine(Teleport()); 
        audio.Play();
    }
   

    IEnumerator Teleport()
    {
       // GameObject.FindGameObjectWithTag("Player").transform.localScale *= 1 * Time.deltaTime;
        yield return new WaitForSeconds(0.001f);
        //SceneManager.LoadScene("BeyondPortal");
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + Flag,LoadSceneMode.Single);
        //if(Flag == -1)
        GameObject.FindGameObjectWithTag("Player").transform.position =  positionn.position;

        
    }
}
