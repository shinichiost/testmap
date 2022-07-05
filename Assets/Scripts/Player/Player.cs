using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private int health = 3;
    public GameObject[] healthlist = new GameObject[3];
    [SerializeField]
    private bool isdead = false, win = false;
    public List<GameObject> playerlist;
    private GameObject player ;
    public static Player instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        player = getPlayer();
        player.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var EnermyParent = collision.collider.transform.parent.gameObject;
        if (EnermyParent.CompareTag("Enermy"))
        {
            health -= 1;
            if (health >= 0)
                Destroy(healthlist[health]);

            if(health == 0)
                isdead = true;
        }
        if (collision.collider.CompareTag("Cup"))
            win = true;
    }
    public bool getLose()
    {
        return this.isdead;
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
}
