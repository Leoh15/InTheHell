using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformMove : MonoBehaviour {

    public float movX, movY, time, timeMov;
    public bool X, Y, direita, esquerda, cima, baixo, verticalD, verticalS;
    Vector3 posicao;

    // Use this for initialization
    void Start ()
    {
        time = timeMov;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Movimentar();
	}

    void Movimentar()
    {
        if (cima)
            transform.Translate(Vector3.up * movY * Time.deltaTime);
        else if (baixo)
            transform.Translate(Vector3.down * movY * Time.deltaTime);
        else if (direita)
            transform.Translate(Vector3.right * movX * Time.deltaTime);
        else if (esquerda)
            transform.Translate(Vector3.left * movX * Time.deltaTime);
        else if (verticalD)
        {
            transform.Translate(Vector3.right * movX * Time.deltaTime);
            transform.Translate(Vector3.down * movY * Time.deltaTime);
        }
        else if (verticalS)
        {
            transform.Translate(Vector3.left * movX * Time.deltaTime);
            transform.Translate(Vector3.up * movY * Time.deltaTime);
        }
        MudarDirecao();
    }

    void MudarDirecao()
    {
        time = time - Time.deltaTime;

        if (time <= 0)
        {
            if (cima)
            {
                baixo = true; cima = false;
            }
            else if (baixo)
            {
                cima = true; baixo = false;
            }
            else if (direita)
            {
                esquerda = true; direita = false;
            }
            else if (esquerda)
            {
                direita = true; esquerda = false;
            }
            else if(verticalD)
            {
                verticalS = true; verticalD = false;
            }
            else if(verticalS)
            {
                verticalD = true; verticalS = false;
            }

            time = timeMov;
        }
    }
    	
	void OnCollisionStay2D(Collision2D colider)
    {
 	    if(colider.gameObject.tag == "Player")
        {
	        colider.gameObject.transform.parent = transform;
        }
    }

	void OnCollisionExit2D(Collision2D colider)
    {
		if (colider.gameObject.tag == "Player")
 		{
			colider.gameObject.transform.parent = null;
		}
    }
}