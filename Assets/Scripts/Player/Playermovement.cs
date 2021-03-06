using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using System;
public class Playermovement : MonoBehaviour
{
    private Rigidbody2D rb;
    Transform playermover;
    //jump
    [Range(1f,100f)]
    private float jumpforce = 200f;
    private float dbjumpforce = 30f;

    //move
    [Range(1f, 100f)]
    private float movespeed = 3f;
    private float movem = 0,move = 0;
    [SerializeField]
    private bool isfalling = false, isGrounded = false;
    //animator
    Animator anim;
    //health
    public List<GameObject> healthlist = new List<GameObject>();
    public Player player;
    private PauseMenu pause;
    IEnumerator Start()
    {
        playermover = GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponentsInChildren<Animator>()[0];
        yield return null;
        int index = CharacterSelectionada.getIndex();

    }


    void Update()
    {
        movePlayer();
        movePlayerbymouse();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
            isGrounded = true;
 
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
            isGrounded = false;
    }
    public void movePlayerbymouse()

    {
        movem = CrossPlatformInputManager.GetAxis("Horizontal");

        if (movem != 0)
        {
            if(isGrounded)
            anim.SetInteger("animationstate",(int)Mathf.Abs(movem));
            transform.localScale = new Vector3(movem, 1, 1);
        }
        playermover.Translate(Vector3.right * movem * movespeed * Time.deltaTime);
        if (CrossPlatformInputManager.GetButtonDown("Jump") && isGrounded)
        {
            //anim.SetInteger("animationstate", 2);
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            isfalling = true;
        }
        
    }
    public void movePlayer()
    {
        move = Input.GetAxisRaw("Horizontal");
        if (move != 0 )
        {
            if (isGrounded)
                anim.SetInteger("animationstate", (int)Mathf.Abs(move));
            transform.localScale = new Vector3(move, 1, 1);
        }
        playermover.Translate(Vector3.right * move * movespeed * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //anim.SetInteger("animationstate", 2);
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);   
        }
        
    }
  


    public void setGrounded(bool isgrounded)
    {
        this.isGrounded = isgrounded;
    }
    public void moveleft()
    {
        transform.localScale = new Vector3(-1, 1, 1);
        playermover.Translate(Vector3.right  *-1* movespeed*Time.deltaTime);
    }
    public void moveright()
    {
        transform.localScale = new Vector3(1, 1, 1);
        playermover.Translate(Vector3.right * movespeed*Time.deltaTime );
    }
    //public void jump()
    //{
    //    jumping += 1;
    //    if (jumping == 1)
    //    {
    //        rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
    //    }
    //    else if (jumping == 2)
    //    {
    //        rb.AddForce(Vector2.up * dbjumpforce, ForceMode2D.Impulse);
    //    }
    //}

}
