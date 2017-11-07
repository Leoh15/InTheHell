using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperBoss : MonoBehaviour {
    
    Animator portaoAnimator, ui, boss;
    Rigidbody2D rb;
    bool atacar;
    public bool direita, esquerda;
    public float tempo;
    GameObject player, portao, bossUi;
    float hp, tempoAE;
    Vector2 pulinho;
    public GameObject monsterMorte;
    BoxCollider2D box;
    GameObject[] hearts;

    // Use this for initialization
    void Start ()
    {
        boss = GetComponent<Animator>();
        hearts = GameObject.FindGameObjectsWithTag("HeartBoss");
        portao = GameObject.Find("Portao");
        portaoAnimator = portao.GetComponent<Animator>();
        box = portao.GetComponent<BoxCollider2D>();
        hp = 5;
		player = Player.playerG;
		atacar = true;
        rb = GetComponent<Rigidbody2D>();
        bossUi = GameObject.Find("BossLife");
	}	

    void Update()
    {
        Destroyer();
        Life();
    }
	// Update is called once per frame
	void FixedUpdate ()
    {
        Jumper();
        MudarDirecao();
	}
    
    void Jumper()
    {
        if (atacar == true)
        {
            if (direita == true)
            {
                tempo = tempo - Time.deltaTime;
                pulinho = new Vector2(-2.5f, 5.5f);

                if (tempo < 0)
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    tempo = 1.75f;
                    //animator.SetBool("Pular", true);
                    rb.AddForce(pulinho, ForceMode2D.Impulse);
                }
            }
            else
            {
                tempo = tempo - Time.deltaTime;
                pulinho = new Vector2(2.5f, 5.5f);

                if (tempo < 0)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    tempo = 1.75f;
                    //animator.SetBool("Pular", true);
                    rb.AddForce(pulinho, ForceMode2D.Impulse);
                }
            }
        }
    } // Código de movimentação do Jumper
    
    void MudarDirecao()
    {
        Vector3 distancia = gameObject.transform.position - player.transform.position;

        if (distancia.x > 0) { direita = true; esquerda = false; }
        else {esquerda = true; direita = false;}

    } // Muda a direção do Jumper
    
    void Destroyer()
    {
        if(hp <= 0)
        {
            ui = GameObject.Find("BossLife").GetComponent<Animator>(); ui.SetBool("Fechar", true); 
            portaoAnimator.SetBool("Desceu", true);
            monsterMorte.transform.position = transform.position;
            Destroy(box);
            Instantiate(monsterMorte);
            Destroy(gameObject);
        }
    }

    void Life()
    {
        if (hp == 4)
            Destroy(hearts[0]);
        else if (hp == 3)
            Destroy(hearts[1]);
        else if (hp == 2)
            Destroy(hearts[2]);
        else if (hp == 1)
            Destroy(hearts[3]);
        else if (hp == 0)
            Destroy(hearts[4]);
    }

    void OnTriggerEnter2D(Collider2D colider)
    {
        if (colider.gameObject.tag == "Tiro")
        {
            hp--;
            Destroy(colider.gameObject);
        }

        if (colider.gameObject.tag == "Player")
        {
            hp--;
        }
    }

    void OnCollisionEnter2D(Collision2D colider)
    {
        if(colider.gameObject.tag == "Plataforma")
        {
            boss.SetTrigger("Chao");
        }

        if(colider.gameObject.tag == "Tiro")
        {
            hp--;
            Destroy(colider.gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D colider)
    {
        if (colider.gameObject.tag == "Plataforma")
        {
            boss.SetTrigger("Pulou");
        }
    }
}
