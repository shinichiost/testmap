using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
public class Playermovement : MonoBehaviour
{
    private Rigidbody2D rb;
    Transform playermover;
    //jump
    [Range(1f,100f)]
    private float jumpforce = 200f;
    private float dbjumpforce = 30f;
    [SerializeField]
    private int jumping;
    //move
    [Range(1f, 100f)]
    private float movespeed = 2f;
    private float movem = 1,move = 1;
    [SerializeField]
    private bool isfalling = false, isGrounded = false;
    //animator
    Animator anim;
    //health
    public List<GameObject> healthlist = new List<GameObject>();
    public Player player;
    private PauseMenu pause;
    void Start()
    {
        playermover = GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

    }


    void Update()
    {
        //movePlayer();
        movePlayerbymouse();
        if (isGrounded)
            jumping = 0;
        if (rb.velocity.y < 0)
            isfalling = true;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
            isGrounded = true;
        if (collision.collider.CompareTag("DeadZone"))
        {
            Time.timeScale = 0;

        }
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
            //           anim.SetInteger("animationstate", 1);
            transform.localScale = new Vector3(movem, 1, 1);
        }
        playermover.Translate(Vector3.right * movem * movespeed * Time.deltaTime);
        if (CrossPlatformInputManager.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            isfalling = true;
        }
    }
    public void movePlayer()
    {
        move = Input.GetAxisRaw("Horizontal");

        if (move != 0)
        {
            //           anim.SetInteger("animationstate", 1);
            transform.localScale = new Vector3(move, 1, 1);
        }
        playermover.Translate(Vector3.right * move * movespeed * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
                rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);   
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
