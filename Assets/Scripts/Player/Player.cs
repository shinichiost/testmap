using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private int health = 3;
    public GameObject[] healthlist = new GameObject[3];
    [SerializeField]
    private bool isdead = false, win = false, isfalling = false;
    public List<GameObject> playerlist;
    public static Player instance;
    private Rigidbody2D rb;
    public GameObject enermy;
    public GameObject winbanner;
    public GameObject losebanner;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject player = getPlayer();
        player.SetActive(true);
        
    }
    private void Update()
    {
        if (win) UIManager.instance.showwinbanner(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Ground"))
        {
            var EnermyParent = collision.collider.transform.parent.gameObject;
            if (EnermyParent.CompareTag("Enermy"))
            {
                if (rb.velocity.y < 0)
                {
                    Destroy(collision.collider);
                }
                else
                {
                    health -= 1;
                    if (health >= 0)
                        Destroy(healthlist[health]);
                    transform.Translate(-Vector3.right * Input.GetAxis("Horizontal") * 30f * Time.deltaTime);
                    if (health == 0)
                        isdead = true;
                }

            }
            if (collision.collider.CompareTag("Cup"))
                win = true;
        }
    }



    public bool getLose()
    {
        return this.isdead;
    }
    public void setLose(bool isdead)
    {
        this.isdead = isdead;
    }
    public bool getWin()
    {
        return this.win;
    }
    public GameObject getPlayer()
    {
        return playerlist[CharacterSelection.instance.getIndex()];
    }
    public void decreaseHealth()
    {
        this.health += 1;
    }
    // observer pattern
    public void Notify()
    {
        
    }

}
