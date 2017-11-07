using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botao : MonoBehaviour {

    Animator animator;
    public Rigidbody2D rb;
    BoxCollider2D box;
    public bool rbB; 

	// Use this for initialization
	void Start ()
    {
        box = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
	}

    void OnCollisionEnter2D(Collision2D colider)
    {
        if(colider.gameObject.tag == "Player")
        {
            Destroy(box);
            animator.SetBool("Apertou", true);
            if(rbB)
                rb.simulated = true;
        }
    }
}