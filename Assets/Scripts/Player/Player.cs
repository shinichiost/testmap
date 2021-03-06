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
    IEnumerator Start()
    {
        yield return null;
        int index = CharacterSelection.getIndex();
        anim = gameObject.GetComponentsInChildren<Animator>()[0];
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
        if (collision.collider.tag != "Ground")
        {

            if (collision.collider.transform.parent.gameObject != null)
            {
                var EnermyParent = collision.collider.transform.parent.gameObject;

                if (EnermyParent.CompareTag("Enermy"))
                {
                    if (rb.velocity.y < 0)
                    {
                        if (collision.collider.tag != "Ocsen")
                            Destroy(collision.collider);

                    }
                    else
                    {
                        decreaseHealth();
                        
                        
                    }

                }
                if (collision.collider.CompareTag("Cup"))
                {
                    win = true;
                    UIManager.instance.showwinbanner(win);
                }
            }


        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ocsen"))
            {
            
        }
        if (collision.CompareTag("Apple"))
        {
            score++;
            collision.gameObject.SetActive(false);
        }
        if (collision.CompareTag("DeadZone"))
        {
            isdead = true;
            UIManager.instance.showlosebanner(isdead);
        }
        if(collision.CompareTag("Bullet"))
        {
            decreaseHealth();
            collision.gameObject.SetActive(false);
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
        return playerlist[CharacterSelection.getIndex()];
    }
    public void increaseHealth()
    {
        this.health += 1;
    }
    public void decreaseHealth()
    {
        anim.Play("player_hit");
        health -= 1;
        if (health >= 0)
            healthlist[health].SetActive(false);
        //float t = 2f;
        //while (t > 0)
        //{
        //    t -= Time.deltaTime;
        //    transform.Translate(-Vector3.right * Input.GetAxis("Horizontal") * 0.2f * Time.deltaTime);
        //}
        if (health == 0)
        {
            isdead = true;
            UIManager.instance.showlosebanner(isdead);
        }
    }
    

}
