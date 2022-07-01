using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    private Rigidbody2D rb;
    Transform playermover;
    //jump
    [Range(1f,100f)]
    private float jumpforce = 5f;
    private float dbjumpforce = 3f;
    private int jumping;
    //move
    [Range(1f, 100f)]
    private float movespeed = 2f;
    private float move;
    private bool isfalling = false, isgrounded = false;
    //animator
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        playermover = GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        jumping = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        if (isgrounded)
            jumping = 0;
    }
    public void movePlayer()
    {
        move = Input.GetAxisRaw("Horizontal");
        if (move != 0)
            anim.SetInteger("animationstate", 1);
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
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            isgrounded = true;
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isgrounded = false;
        }
    }
}
