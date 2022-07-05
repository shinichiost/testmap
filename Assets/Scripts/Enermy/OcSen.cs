using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class OcSen : MonoBehaviour
{
    public Transform rootPosition;
    private int direct = -1;
    float movespeed = 2f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        snailMoving();
    }

     
    void Update()
    {
        
    }
    public void snailMoving()
    {

        if (Math.Abs(transform.localPosition.x) < 2.5)
            rb.MovePosition(transform.position + direct * movespeed * Time.deltaTime * Vector3.right);
        else
            changedirect();
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Ground"))
            changedirect();
    }
    private void changedirect()
    { 
        direct = -direct;
        transform.localScale = Vector3.right * direct;
    }
}
