using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playermovement : MonoBehaviour
{
    private Rigidbody2D rb;
    Transform playermover;
    //jump
    [Range(1f,100f)]
    private float jumpforce = 100f;
    private float dbjumpforce = 30f;
    private int jumping;
    //move
    [Range(1f, 100f)]
    private float movespeed = 2f;
    private float move = 1;
    [SerializeField]
    private bool isfalling = false, isGrounded = false;
    //animator
    Animator anim;
    //health
    public List<GameObject> healthlist = new List<GameObject>();

    
    void Start()
    {
        playermover = GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

    }


    void Update()
    {
        movePlayer();
        if (isGrounded)
            jumping = 0;
    }
    
    public void movePlayer()
    {
        move = Input.GetAxisRaw("Horizontal");

        if (move != 0)
        {
 //           anim.SetInteger("animationstate", 1);
            transform.localScale = new Vector3(move, 1, 1);
        }
        playermover.Translate(Vector3.right * move* movespeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            jumping += 1;
            if (jumping == 1)
            {
                rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            }
            else if(jumping == 2)
            {
                rb.AddForce(Vector2.up * dbjumpforce, ForceMode2D.Impulse);
            }
            isfalling = true;
        }
    }
   

   
    public void setJumping(int jump){
        this.jumping = jump;
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
    public void jump()
    {
        jumping += 1;
        if (jumping == 1)
        {
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        }
        else if (jumping == 2)
        {
            rb.AddForce(Vector2.up * dbjumpforce, ForceMode2D.Impulse);
        }
    }

}
