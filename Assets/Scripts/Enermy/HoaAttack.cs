using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoaAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator shot()
    {
        yield return new WaitForSeconds(3f);
    }
}
[System.Serializable]
public class Preallocation
{
    public GameObject gameObject;
    public int count;
    public bool expandable;
}

