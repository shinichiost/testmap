using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShowBanner : MonoBehaviour
{
    public GameObject winbanner,losebanner,player;   
    void Start()
    {
        if (Player.instance.getWin())
            winbanner.SetActive(true);
        if (Player.instance.getLose())
            losebanner.SetActive(true);
    }

  
}
