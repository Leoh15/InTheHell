using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    Animator animator;
    SpriteRenderer sprite;
    GameObject monster, monsterDistance;
    public GameObject flechaD, flechaE, fireMorcegoD, fireMorcegoE, logotipo;

    public Vector3 position1, position2 ,positionLogotipo;
    public bool andar, atacar;
    public float tempo, distance, tempoInstance;
    bool distanci, ataqueD, ataqueE, ataqueEspada, morcegos, logotipoB;
    float velocidade;

	// Use this for initialization
	void Start ()
    {
        Physics2D.IgnoreLayerCollision(11, 9, false);
        logotipoB = true;
        morcegos = true;
        ataqueD = true;
        ataqueE = true;
        ataqueEspada = true;
        velocidade = 4;
        andar = true;
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        monster = GameObject.Find("BatDEspecial(Clone)");
        monsterDistance = GameObject.Find("BatEDistance(Clone)");

        Distance();
        Player();
	}

    void Distance()
    {
        if (monsterDistance != null)
        {
            distanci = true;
            distance = Vector3.Distance(transform.position, monsterDistance.transform.position);
        }


        if(distance <= 3 && distanci)
        {
            velocidade = 0;
            atacar = true;
        }
    }

    void Player()
    {
        if (andar)
        {
            animator.SetFloat("Velocidade", 1);
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
        }
        if(atacar)
        {
            animator.SetFloat("Velocidade", 0);
            animator.SetBool("AtaqueE", true);
            tempo -= Time.deltaTime;

            if(tempo <= 0.5)
            {
                animator.SetBool("AtaqueE", false);
            }
            
            if(tempo <= 0 && ataqueEspada)
            {
                sprite.flipX = true;
                animator.SetBool("AtaqueD", true);
                tempo -= Time.deltaTime;
                ataqueEspada = false;
            }

            if(tempo <= -1 && ataqueD)
            {
                animator.SetBool("AtaqueD", false);
                sprite.flipX = false;
                animator.SetBool("AtaqueArco", true);
                flechaD.transform.position = transform.position + new Vector3(0.5f, 0, 0);
                Instantiate(flechaD);
                ataqueD = false;
            }
            if(tempo <= -2 && ataqueE)
            {
                sprite.flipX = true;
                animator.SetBool("AtaqueArco", true);
                flechaE.transform.position = transform.position - new Vector3(0.5f, 0, 0);
                Instantiate(flechaE);
                ataqueE = false;
            }
            if(tempo <= -3.2 && morcegos)
            {
                fireMorcegoD.transform.position = position1;
                Instantiate(fireMorcegoD);
                fireMorcegoE.transform.position = position2;
                Instantiate(fireMorcegoE);
                morcegos = false;
            }
            if(tempo <= -5 && logotipoB)
            {
                logotipo.transform.position = positionLogotipo;
                Instantiate(logotipo);
                logotipoB = false;
            }
        }
    }    
}