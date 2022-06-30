using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        camerafollow();
    }
    public void camerafollow()
    {
        if (player.transform.position.x < 0)
            return;
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }
}
