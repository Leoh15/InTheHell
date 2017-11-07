using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBat : MonoBehaviour {

    //MovimentoEspiral
    Vector3 a, b, c, frequencia;
    bool cima, baixo;

    public GameObject fireBallD, fireBallE;
    GameObject player;
    public bool direita, esquerda;
    bool ataque, atvTempo;
    public float velocidade, velocidadeX,timeDirecao, timeDirecaoA, timeAtaque, timeAtaqueA, x, y;
    SpriteRenderer sprite;
    float distance;

    // Use this for initialization
    void Start ()
    {
        cima = true;
        frequencia = new Vector3(0, 1, 0);
        a.y = transform.position.y;
        b.y = a.y + frequencia.y;
        c.y = a.y - frequencia.y;
        //direcao = b;

        timeDirecao = timeDirecaoA;
        sprite = GetComponent<SpriteRenderer>();
//      player = GameObject.FindGameObjectWithTag("Player");
		player = Player.playerG;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.Translate(0, velocidade, 0);
        Movimentacao();
        Ataque();
        FireBall();
    }

    void Movimentacao()
    {
        if(distance < 6)
        {
            if(player.transform.position.x < transform.position.x)
            {
                sprite.flipX = false;
                transform.Translate(Vector2.right * velocidadeX * Time.deltaTime);
            }
            else if (player.transform.position.x > transform.position.x)
            {
                sprite.flipX = true;
                transform.Translate(Vector2.left * velocidadeX * Time.deltaTime);
            }
        }

        if(distance >= 6)
            if (player.transform.position.x < transform.position.x)
            {
                sprite.flipX = false;
                transform.Translate(Vector2.left * velocidadeX * Time.deltaTime);
            }
            else if (player.transform.position.x > transform.position.x)
            {
                sprite.flipX = true;
                transform.Translate(Vector2.right * velocidadeX * Time.deltaTime);
            }
    }

    void Ataque()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance <= 8)
        {
            ataque = true;
        }
        else
        {
            ataque = false;
        }
    }

    void FireBall()
    {
        Vector3 distancia = new Vector3(-1f, 0, 0);

        if(ataque && player.transform.position.x < transform.position.x && atvTempo == false)
        {
            fireBallE.transform.position = transform.position + distancia;
            Instantiate(fireBallE);            
            atvTempo = true;
        }
        else if(ataque && player.transform.position.x > transform.position.x && atvTempo == false)
        {
            fireBallD.transform.position = transform.position - distancia;
            Instantiate(fireBallD);
            atvTempo = true;
        }

        if(atvTempo)
        {
            timeAtaqueA -= Time.deltaTime;
        }

        if(timeAtaqueA <= 0)
        {
            atvTempo = false;
            timeAtaqueA = timeAtaque;
        }
    }
}