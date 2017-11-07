using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperNew : MonoBehaviour {

    Rigidbody2D rb;
    public Vector2 puloD, puloE;
    public float tempo, tempoA;
    public bool direita;
    SpriteRenderer sprite;
    Animator animator;
    BoxCollider2D[] box; //[0] - direita ; [1] - esquerda
    bool chao;

	// Use this for initialization
	void Start ()
    {
        box = GetComponents<BoxCollider2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Movimentacao();
	}

    void Movimentacao()
    {
        animator.SetBool("Automatic", true);
        tempoA -= Time.deltaTime;

        if(tempoA <= 0 && chao)
        {
            if(direita)
            {
                box[0].enabled = false;
                box[1].enabled = true;
                sprite.flipX = false;
                rb.AddForce(puloD, ForceMode2D.Impulse);
                tempoA = tempo;
            }
            else
            {
                box[0].enabled = true;
                box[1].enabled = false;
                sprite.flipX = true;
                rb.AddForce(puloE, ForceMode2D.Impulse);
                tempoA = tempo;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D colider)
    {
        if(colider.gameObject.tag == "Plataforma") { chao = true;}

        if(colider.gameObject.name == "Parede")
        {
            if(direita)
            {
                direita = false;
            }
            else
            {
                direita = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D colider)
    {
        if (colider.gameObject.tag == "Plataforma") { chao = false; }
    }
}
