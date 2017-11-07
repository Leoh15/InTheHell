using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechasAdd : MonoBehaviour {
    
    void OnCollisionEnter2D(Collision2D colider)
    {
        if (colider.gameObject.tag == "Player")
        {
            if(Player.numeroFlechas <= 5) { Player.numeroFlechas += 5; Destroy(gameObject); }
            else if(Player.numeroFlechas == 10) { Inventario.flechas = true; Destroy(gameObject); }
            else
            {
                int flechas = 10 - Player.numeroFlechas;
                Player.numeroFlechas += flechas;
                Destroy(gameObject);
            }
        }
    }

}
