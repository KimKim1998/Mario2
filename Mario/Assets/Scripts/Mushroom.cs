using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public GameObject Player;

    void Start()
    {

    }
     

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            this.transform.position = new Vector3(0 - 1000, 0);
        Player.transform.localScale += new Vector3(0.1F, 0.1F, 0.1F);



    }
}
