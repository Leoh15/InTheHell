using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    GameObject player;
    public float distMax, distMin;
    bool seguir;

    void Start()
    {
		player = Player.playerG;
    }

    void Update()
    {
    }

    void Seguir()
    {
        if (player.transform.position.x >= distMin && player.transform.position.x <= distMax) { seguir = true; }

        if(seguir)
        {
            transform.parent = player.transform ;
        }
    }
}