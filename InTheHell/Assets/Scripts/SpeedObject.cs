using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedObject : MonoBehaviour {
    
    //Componentes
        //Private's
        Animator animator; // Animator dos objetos
        //Rigidbody2D rb; // Rigidbody do gameObjetc
        Transform playerPosition; // Pega a posição do player

    //Variáveis
        //Public's
            public bool atacar, baixo, cima, direita, esquerda, fireBall, mudarDirecao, movX, player, pulo;
            public float velocidadeX, velocidadeY;
            public int hp;
            public Vector2 impulso;
        
        //Private's
        float tempo;

    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Player();
        MovX();
        MovY();
    }

    void Player()
    {

        if (player)
            animator.SetFloat("Velocidade", 1);
            if (direita)
                transform.Translate(Vector2.right * velocidadeX * Time.deltaTime);
            else if (esquerda)
                transform.Translate(Vector2.left * velocidadeX * Time.deltaTime);
    }

    void MovX()
    {
        if(atacar == true)
        {
            if (direita == true)
                transform.Translate(Vector2.right * velocidadeX * Time.deltaTime);
            else if (esquerda == true)
                transform.Translate(Vector2.left * velocidadeX * Time.deltaTime);
        }
    }

    void MovY()
    {
        if (cima == true)
            transform.Translate(Vector2.up * velocidadeY * Time.deltaTime);
        if (baixo == true)
            transform.Translate(Vector2.down * velocidadeY * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D colider)
    {
        if (colider.tag == "Player")
        {
            atacar = true;
        }
    }
}