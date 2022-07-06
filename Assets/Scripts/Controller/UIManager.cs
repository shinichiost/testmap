using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public GameObject winbanner, losebanner;
    public static UIManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
  
    public void showwinbanner(bool win)
    {
        winbanner.SetActive(win);
    }
    public void showlosebanner(bool lose)
    {
        losebanner.SetActive(lose);
    }
}
