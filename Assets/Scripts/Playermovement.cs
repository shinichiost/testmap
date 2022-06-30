using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    Transform playermover;
    [Range(1f,100f)]
    private float jumpforce = 10f;
    [Range(1f, 100f)]
    private float movespeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        playermover = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }
    public void movePlayer()
    {
        if (Input.GetKey(KeyCode.A))
            playermover.Translate(Vector3.left * movespeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            playermover.Translate(Vector3.right * movespeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            playermover.Translate(Vector3.up * jumpforce * Time.deltaTime);
    }
}
