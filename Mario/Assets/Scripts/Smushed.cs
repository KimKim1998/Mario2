using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smushed : MonoBehaviour
{
    public AudioSource Stomp;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            foreach (Transform child in transform)
                child.gameObject.SetActive(false);


            Stomp.Play();

            Destroy(transform.parent.gameObject);
            

        }
    }

   
}

          



    
    

    

   

