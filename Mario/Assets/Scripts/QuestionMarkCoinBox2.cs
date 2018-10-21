using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionMarkCoinBox2 : MonoBehaviour
{
    
    public GameObject pickupPrefab;
    public Material usedMat;
    private Transform Player;




    void HitZone()
    {
        Instantiate(pickupPrefab, transform.position + Vector3.up, transform.rotation);
        transform.parent.GetComponent<Renderer>().material = usedMat;
        GetComponent<BoxCollider>().enabled = false;


    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            HitZone();
        

           
    }
}
        
        
    
        
        
    














