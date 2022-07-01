using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    private GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        character = CharacterController.instance.character();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
