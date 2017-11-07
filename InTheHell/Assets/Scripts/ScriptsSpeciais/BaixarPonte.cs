using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaixarPonte : MonoBehaviour {
    
    BoxCollider2D box;
    Rigidbody2D rb;
    Animator animator;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
	}
	
    void OnCollisionEnter2D(Collision2D colider)
    {
        if(colider.gameObject.tag == "Enemy")
        {
            animator.SetBool("Quebrou", true);
            rb.gravityScale = 1;
            Destroy(box);
        }
    }

    void OnTriggerEnter2D(Collider2D colider)
    {
        if (colider.gameObject.tag == "Enemy")
        {
            animator.SetBool("Quebrou", true);
            rb.gravityScale = 3;
            Destroy(box);
        }
    }
}
