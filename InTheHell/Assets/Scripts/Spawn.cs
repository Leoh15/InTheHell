using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    
    public float distancia;
    public float distance;
    GameObject player;
    public GameObject enemyD, enemyE, portal;
    int quantidade;
    public bool direita, soD, soE;

	// Use this for initialization
	void Start ()
    {
        quantidade = 1;
		player = Player.playerG;
	}
	
	// Update is called once per frame
	void Update ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Direcao();
        Spawnar();
	}

    void Direcao()
    {
        if(soD == false && soE == false)
        {
            if (player.transform.position.x > transform.position.x)
            {
                direita = true;
            }
            else
            {
                direita = false;
            }
        }
    }

    void Spawnar()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance <= distancia && quantidade == 1)
        {
            portal.transform.position = transform.position;
            enemyD.transform.position = transform.position;
            enemyE.transform.position = transform.position;

            if (direita || soD)
            {
                Instantiate(portal);
                Instantiate(enemyD);
            }
            else if(direita == false || soE)
            {
                Instantiate(portal);
                Instantiate(enemyE);
            }
            quantidade = 0;
        }
        else if(distance > distancia)
        {
            quantidade = 1;
        }
    }
}