using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    Vector3 luz = new Vector3(0, 0, -1);
    public GameObject item, particles;
    public float tempo;
    public int tempoRestart;
    bool direita;
    public bool particlesB;
    float tempoAleatorio;
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        tempoAleatorio = tempo + 3;
        tempo = tempo - Time.deltaTime;
        Instanciar();
    }

    void Instanciar()
    {
        if(tempo <= 0)
        {
            tempo = tempoRestart;
            item.transform.position = gameObject.transform.position + luz;
            if (particles) { particles.transform.position = transform.position; Instantiate(particles);}
            Instantiate(item);
        }
    }
}