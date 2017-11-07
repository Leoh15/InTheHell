using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Redimensionar : MonoBehaviour {

    SpriteRenderer sprite;
    public Vector3 scale, size, size2;
    float tempo = 0.05f, tempoMorreu = 2;
    public bool aumentar, diminuir;
    GameObject player, kmera;
    public static bool morreu;

	// Use this for initialization
	void Start ()
    {
		player = Player.playerG;
        sprite = GetComponent<SpriteRenderer>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Temporalizador();

        if(morreu)
        {
            kmera = GameObject.FindGameObjectWithTag("MainCamera");
            transform.position = kmera.transform.position;
            tempoMorreu -= Time.deltaTime;

            if (tempoMorreu <= 0)
                aumentar = true;
                Aumentar();
        }
	}

    void Temporalizador()
    {
        if (diminuir)
        {
            transform.localScale -= scale;

            if(transform.localScale == size)
            {
                diminuir = false;
            }
        }
    }

    void Aumentar()
    {
        transform.localScale += scale;

        if (transform.localScale.x >= size2.x && aumentar)
        {
            aumentar = false;
        }
        if(aumentar == false)
        {
            SceneManager.LoadScene(19);
        }
    }
}