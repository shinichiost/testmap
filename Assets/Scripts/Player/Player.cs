using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private int health = 3;
    public GameObject[] healthlist = new GameObject[3];
    private bool Dead = false;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject player = CharacterController.instance.character();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enermy")
        {
            health -= 1;
            if (health >= 0)
                Destroy(healthlist[health]);

            else
                Dead = true;
        }
    }
}
