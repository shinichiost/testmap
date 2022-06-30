using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterController : MonoBehaviour
{
    public static CharacterController instance { get; private set; }
    [Header("Character :")]
    public List<GameObject> gameoj = new List<GameObject>();
    private GameObject oj;
    private int index ;
    public Button btnleft, btnright;
    private void Awake()
    {
        
        instance = this;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        oj = character();
 
    }

    // Update is called once per frame
    void Update()
    {
        oj.SetActive(true);
        btnleft.onClick.AddListener(decreaseIndex);
        btnright.onClick.AddListener(increaseIndex);

    }
    void decreaseIndex()
    {
        oj.SetActive(false);
        if(index > 0)
            index -= 1;
        else
            index = gameoj.Count - 1;
        oj = character();
        oj.SetActive(true);
    }
    void increaseIndex()
    {
        oj.SetActive(false);
        if (index < gameoj.Count - 1)
            index += 1;
        else
            index = 0;
        oj = character();
        oj.SetActive(true);
    }
    private GameObject character()
    {
        return gameoj[index];
    }
}
