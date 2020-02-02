using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController2D : MonoBehaviour
{

    [SerializeField] GameObject blabla;
    [SerializeField] AudioSource audio;
    [SerializeField] private GameObject loadIcon = null;
    [SerializeField] private List< GameObject> Bricks;
    [SerializeField] private int index =1;
    public bool hit;
    public float JumpSpeed = 5;
    public float JumpForce = 50f;
    public float MovementSpeed = 3;
    bool IsGrounded = true;
    public int BlocksCount = 0;
    public bool CanDoubleJump;
    public bridge bb;
   // public Text text;
    AudioSource source;
    List<GameObject> Ground = new List<GameObject>();
    Animator animator;
    Rigidbody2D rigidbody2D;
    int childrenCount;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>(); 
        loadIcon.SetActive(false);
        childrenCount = bb.transform.childCount;
        audio.Play();

    }

    void Update()
    {
        if (Input.GetButtonDown("Jump")) 
        {
            if(Ground.Count > 0)
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, JumpSpeed);
                rigidbody2D.AddForce(new Vector2(0, JumpForce));
                animator.SetBool("isJumping", true);
                CanDoubleJump = true;
            }
            else
            {
                if(CanDoubleJump)
                {
                    rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, JumpSpeed);
                    rigidbody2D.AddForce(new Vector2(0, JumpForce));
                    animator.SetBool("isJumping", true);
                    CanDoubleJump = false;

                }
            }
        }

        if (Input.GetButtonUp("Jump") && rigidbody2D.velocity.y > 0)
        {
            if(CanDoubleJump && Input.GetButtonDown("Jump") && Ground.Count == 0)
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, JumpSpeed);
                rigidbody2D.AddForce(new Vector2(0, JumpForce));
                animator.SetBool("isJumping", true);
                CanDoubleJump = false;
            }
            else
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
        }

        rigidbody2D.velocity = new Vector2( MovementSpeed *Input.GetAxis("Horizontal"), rigidbody2D.velocity.y);
        
        if(rigidbody2D.velocity.y <0 )
        {
            rigidbody2D.gravityScale = 4;
        }
        else 
        {
            rigidbody2D.gravityScale = 1;
        }

        if(rigidbody2D.velocity.x > 0)
        {
            transform.right = Vector2.right;
        }
        else if(rigidbody2D.velocity.x < 0)
        {
            transform.right = Vector2.left;
        }
        animator.SetFloat("velocity", rigidbody2D.velocity.x);
        if (Input.GetKeyDown(KeyCode.R))
        {
           
            if (index<=Bricks.Count-1 && hit ==false)
            {
                if(Vector2.Distance( Bricks[index].transform.position, bb.transform.GetChild(childrenCount - 1).position) <0.5f)
                {  
                    Destroy(blabla.gameObject);
                    Debug.Log("Win");
                }
                Bricks[index].gameObject.SetActive(true);
            index++;
               
            }
            
        }
        }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            ContactPoint2D[] contacts = collision.contacts;
            for (int i = 0; i < contacts.Length; i++)
            {
                if(contacts[i].normal == Vector2.up)
                {
                    Ground.Add(collision.gameObject);
                    IsGrounded = true;
                    animator.SetBool("isJumping", false);
                    return;
                }
            }
        }

        //if (collision.gameObject.CompareTag("enemy"))
        //{
        //    Destroy(transform.GetComponent<CapsuleCollider2D>());
        //    //text.enabled = true;
        //    //text.gameObject.SetActive(true);
        //}
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if(Ground.Contains(collision.gameObject))
            {
                Ground.Remove(collision.gameObject);
            }
            IsGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Blocks"))
        {
            BlocksCount++;
            Destroy(collision.gameObject);
          //  source.Play();
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Player trigger with something");
        if (collision.CompareTag("Blocks"))
        {
            Debug.Log("HHHHHHHHHHHHHHHH");

            if (Input.GetKey(KeyCode.Q))
            {

                collision.GetComponent<FadeOut>().startFadeout();
                StartCoroutine("CutTrees", collision.gameObject);
            }
        }


    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        loadIcon.SetActive(true);
    }


        IEnumerator CutTrees(GameObject gameObject)
    {
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezePosition;
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
        //loadIcon.SetActive(false);
        rigidbody2D.constraints = RigidbodyConstraints2D.None;
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

}
