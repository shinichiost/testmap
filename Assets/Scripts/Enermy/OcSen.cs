using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class OcSen : MonoBehaviour
{
    public Transform rootPosition;
    private int direct = 1;
    float movespeed = 1.5f;
    private Rigidbody2D rb,playerrb;
    private Animator anim;
    private float waitforchangestate = 4f;
    void Start()
    {
        anim = gameObject.transform.GetChild(0).GetComponent<Animator>();
        anim.SetInteger("animationstate", 0);
        rb = gameObject.GetComponent<Rigidbody2D>();
        waitforchangestate = 4f;
    }

     
    void Update()
    {
        snailMoving();
    }
    public void snailMoving()
    {
        int temp = anim.GetInteger("animationstate");
        if (temp == 0)
            rb.velocity = -Vector2.right * movespeed * direct;
        else if (temp == 1)
            rb.velocity = Vector2.zero;
        else if (temp == 2)
        {
            rb.velocity = -Vector2.right * 4f * direct;
            if (waitforchangestate > 0)
            {
                waitforchangestate -= Time.deltaTime;
            }
            else
            {
                temp = 0;
                anim.SetInteger("animationstate", 0);
                waitforchangestate = 4f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Tuong"))
            changedirection();
    }

 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && collision.collider.GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            int temp = anim.GetInteger("animationstate");
            if (temp == 0)
            {
                anim.SetInteger("animationstate", 1);
            }
            else if (temp == 1)
            {
                anim.SetInteger("animationstate", 2);
            }
        }
            
    }
    private void changedirection()
    { 
        direct = -direct;
        transform.localScale = new Vector3(direct,1,1);
    }
}
