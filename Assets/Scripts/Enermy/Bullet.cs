using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 3f;
    [SerializeField]private Rigidbody2D rb;

    private void FixedUpdate()
    {
        rb.velocity = Vector2.left * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
