using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ponte : MonoBehaviour {

    public Rigidbody2D rb; // RigidBody da ponte
    public Vector2 forca; 

    void OnTriggerEnter2D(Collider2D colider)
    {
        if(colider.gameObject.tag == "Player")
        {
            rb.AddForce(forca, ForceMode2D.Force);
        }
    }
}