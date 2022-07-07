using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    private int health = 3,score = 0;
    public GameObject[] healthlist = new GameObject[3];
    [SerializeField]
    private bool isdead = false, win = false, isfalling = false;
    public List<GameObject> playerlist;
    public static Player instance;
    private Rigidbody2D rb;
    public GameObject enermy;
    public GameObject winbanner;
    public GameObject losebanner;
    private Animator anim;
    public Text scoretext;
    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        GameObject player = getPlayer();
        player.SetActive(true);
        
    }
    private void Update()
    {
        
        scoretext.text = "x" + score.ToString();
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
                    if(collision.collider.tag != "Ocsen")
                        Destroy(collision.collider);
                    
                }
                else
                {
                    anim.SetBool("ishitting", true);
                    health -= 1;
                    if (health >= 0)
                        Destroy(healthlist[health]);
                    float t = 2f;
                    while (t > 0)
                    {
                        t -= Time.deltaTime;
                        transform.Translate(-Vector3.right * Input.GetAxis("Horizontal") *0.2f* Time.deltaTime);
                    }
                    if (health == 0)
                        isdead = true;
                }

            }
            if (collision.collider.CompareTag("Cup"))
            {
                win = true;
                UIManager.instance.showwinbanner(win);
            }

            }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ocsen"))
            {
            anim.SetBool("ishitting", true);
            health -= 1;
            if (health >= 0)
                Destroy(healthlist[health]);
            transform.Translate(-Vector3.right * Input.GetAxis("Horizontal") * 30f * Time.deltaTime);
            if (health == 0)
                UIManager.instance.showlosebanner(isdead);
        }
        if (collision.CompareTag("Apple"))
        {
            score++;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("DeadZone"))
        {
            isdead = true;
            UIManager.instance.showlosebanner(isdead);
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
    

}
