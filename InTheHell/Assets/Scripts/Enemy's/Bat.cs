using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour {


    Animator animator;
    BoxCollider2D box;
    public float movX, movY, time, timeMov;
    public bool X, Y, direita, esquerda,cima, baixo;
    SpriteRenderer sprite;

	// Use this for initialization
	void Start ()
    {
        box = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        time = timeMov;
    }

	// Update is called once per frame
	void FixedUpdate ()
    {
        Movimentar();
	}

    void Movimentar()
    {
        if (cima)
        {
            transform.Translate(Vector3.up * movY * Time.deltaTime);
            sprite.flipX = true;
        }
        else if (baixo)
        {
            transform.Translate(Vector3.down * movY * Time.deltaTime);
            sprite.flipX = false;
        }
        else if (direita)
        {
            transform.Translate(Vector3.right * movX * Time.deltaTime);
            sprite.flipX = true;
        }
        else if(esquerda)
        {
            transform.Translate(Vector3.left * movX * Time.deltaTime);
            sprite.flipX = false;
        }        
    }
    
    void OnCollisionEnter2D(Collision2D colider)
    {
        if(colider.gameObject.tag != "Player")
        {
            if (direita) { direita = false; esquerda = true; }
            else if (esquerda) { esquerda = false; direita = true; }
        }

    }

    void OnTriggerEnter2D(Collider2D colider)
    {
        if(colider.gameObject.tag == "Player" || colider.gameObject.tag == "Tiro")
        {
            Destroy(box);
            movX = 0; movY = 0;
        }
    }
}