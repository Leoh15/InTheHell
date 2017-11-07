using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatarMonstros : MonoBehaviour {

    //Componentes
    float distance, life = 1;
    Animator animator;
    public GameObject LifeOrb, flecha5x, monsterMorte, playerLife;
    int numero;
    GameObject player;
    BoxCollider2D box;
    SpriteRenderer sprite;
    public bool morcego, excecao;
            
	// Use this for initialization
	void Start ()
    {
        sprite = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Destroyer();
	}

    void Destroyer()
    {
        distance = Vector2.Distance(player.transform.position, transform.position);

        if (distance >= 10 && excecao == false)
        {
            Destroy(gameObject);
        }
    }

    void SpawnarItem()
    {
        if (excecao == false)
        {
            if (morcego)
                Player.pontos += 100;
            else
                Player.pontos += 200;

            numero = Random.Range(1, 21);

            if (numero == 10)
            {
                LifeOrb.transform.position = transform.position;
                Instantiate(LifeOrb);
            }
            else if (numero == 20)
            {
                {
                    flecha5x.transform.position = transform.position;
                    Instantiate(flecha5x);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D colider)
    {
        if(colider.gameObject.tag == "Player")
        {
            Player.matou = true;
            sprite.enabled = false;
            Destroy(box);
            SpawnarItem();
            Destroy(gameObject, 0.5f);
            monsterMorte.transform.position = transform.position + new Vector3(0, 0, -2);
            Instantiate(monsterMorte);
        }

        if (colider.gameObject.tag == "Tiro" && life == 0.5 || colider.gameObject.tag == "Tiro" && morcego)
        {
            Player.matou = true;
            sprite.enabled = false;
            Destroy(box);
            SpawnarItem();
            Destroy(gameObject, 0.5f);
            monsterMorte.transform.position = transform.position + new Vector3(0, 0, -2);
            Instantiate(monsterMorte);
        }

        if (colider.gameObject.tag == "Tiro" && life == 1 && morcego == false)
        {
            life -= 0.5f; ;
        }
    }

    void OnCollisionEnter2D(Collision2D colider)
    {
        if(colider.gameObject.tag == "Mata" || colider.gameObject.tag == "Armadilha")
        {
            sprite.enabled = false;
            Destroy(box);
            SpawnarItem();
            Destroy(gameObject, 0.5f);
            monsterMorte.transform.position = transform.position + new Vector3(0,0,-2);
            Instantiate(monsterMorte);
        }
    }
}