using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformSobeDesce : MonoBehaviour {

    public GameObject plataforma;
    public bool ativo, passou;
    bool colidindo;
    
	// Update is called once per frame
	void Update ()
    {
        Subir();
        AtivarDesativar();
	}

    void AtivarDesativar()
    {
        if(ativo)
        {
            plataforma.gameObject.SetActive(true);
        }
        else
        {
            plataforma.gameObject.SetActive(false);
        }
    }

    void Subir()
    {
        if(passou)
        {
            if(ativo)
            {
                ativo = true;
            }
            else
            {
                ativo = false;
            }
        }
    }

    void Descer()
    {
        if(colidindo && Input.GetKeyDown("down"))
        {
            ativo = false;
        }
    }

    void OnTriggerStay2D(Collider2D colider)
    {
        if(colider.gameObject.tag == "Gato")
        {
            colidindo = true;
        }
    }

    void OnTriggerExit2D(Collider2D colider)
    {
        if(colider.gameObject.tag == "Gato")
        {
            passou = true;
        }
    }
}
