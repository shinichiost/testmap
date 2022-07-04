using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoaAttack : MonoBehaviour
{
    [SerializeField] private Transform bulletposition;
    [SerializeField] private GameObject bulletPrefab;
    void Start()
    {
     
    }

 
    void Update()
    {
        GameObject bullet = ObjectPool.instance.getPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = bulletposition.position;
            bullet.SetActive(true);
        }
        //StartCoroutine(shot());
    }
    IEnumerator shot()
    {
        GameObject bullet = ObjectPool.instance.getPooledObject();
        if(bullet != null)
        {
            bullet.transform.position =bulletposition.position;
            bullet.SetActive(true);
        }
        yield return new WaitForSeconds(2.4f);
    }
   
}



