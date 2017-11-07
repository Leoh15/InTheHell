using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddComponentes : MonoBehaviour {

    string name;
    Image sprite;

    void Start()
    {
        sprite = GetComponent<Image>();
        name = sprite.sprite.name;
    }

    void RetirarObjeto()
    {
        if (gameObject.name == "um(Clone)") { Inventario.um = false; }
        else if (gameObject.name == "dois(Clone)") { Inventario.dois = false; }
        else if (gameObject.name == "tres(Clone)") { Inventario.tres = false; }
        else if (gameObject.name == "quatro(Clone)") { Inventario.quatro = false; }
        else if (gameObject.name == "cinco(Clone)") { Inventario.cinco = false; }
        else if (gameObject.name == "seis(Clone)") { Inventario.seis = false; }
    }

    public void EncherLife()
    {
        if (Player.life <= 90) { Player.life += 10; }
        else
        {
            float life = 100 - Player.life;
            Player.life += life;
        }
        RetirarObjeto();
        Destroy(gameObject);
    }

    public void EncherFlecha()
    {
        if (Player.numeroFlechas <= 5) { Player.numeroFlechas += 5; }
        else
        {
            int flechas = 10 - Player.numeroFlechas;
            Player.numeroFlechas += flechas;
        }

        RetirarObjeto();
        Destroy(gameObject);
    }

    void OnTriggerStay2D(Collider2D colider)
    {
        if(colider.gameObject.name == "Select" && Input.GetKeyDown("q"))
        {
            if (name == "LifeOrb10Life") { EncherLife(); }
        }
    }
}
