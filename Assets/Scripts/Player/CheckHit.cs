using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHit : MonoBehaviour
{
    public Playermovement playermovement;
    GameObject player;
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            playermovement.setGrounded(true) ;
        }
        if (collision.collider.CompareTag("Enermy"))
        {
            Destroy(collision.collider);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            playermovement.setGrounded(false);
        }
    }
}
