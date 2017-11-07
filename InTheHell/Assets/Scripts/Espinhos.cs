using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinhos : MonoBehaviour {

    Animator animator;
    public float tempo, tempoA;
    bool ativo; 
    BoxCollider2D box;

	// Use this for initialization
	void Start ()
    {
        ativo = true;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        tempoA -= Time.deltaTime;

        if(tempoA <= 0 && ativo == false)
        {
            animator.SetBool("Ativo", false);
            ativo = true;
            tempoA = tempo;
        }
        if (tempoA <= 0 && ativo)
        {
            animator.SetBool("Ativo", true);
            ativo = false;
            tempoA = tempo;
        }
    }
}