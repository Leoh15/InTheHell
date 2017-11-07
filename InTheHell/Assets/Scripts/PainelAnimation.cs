using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainelAnimation : MonoBehaviour {
    
    GameObject player;
    Animator animator;
    public bool aberto, dialogo;
    public float posAbrir, posFechar, posY;
    float tempo = 2;
    bool parou, time, ativou;

	// Use this for initialization
	void Start ()
    {
		player = Player.playerG;
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (time == true)
        {
            tempo -= Time.deltaTime;

            if(tempo <= 0) { time = false; }
        }

        if(tempo <= 0) { FecharDialogo(); }
        Aberto();
        AbrirDialogo();

	}

    void Aberto()
    {
        if (aberto == true) { time = true; animator.SetBool("Abrir", true);}
    }

    //Abre a caixa de diálogo
    void AbrirDialogo()
    {
        if(aberto == false && ativou == false)
            if (player.transform.position.x >= posAbrir && player.transform.position.y >= posY) {  Player.pausar = true; animator.SetBool("Abrir", true); time = true; ativou = true; }
    }
    //Fecha a caixa de diálogo
    void FecharDialogo()
    {
        if (Input.anyKeyDown && time == false) { animator.SetBool("Fechar", true); Player.pausar = false; }
    }
}