using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarySelect : MonoBehaviour {

    RectTransform rect;
    int positions;
    bool cima, baixo, direita, esquerda;
    float x, y;

	// Use this for initialization
	void Start ()
    {
        rect = GetComponent<RectTransform>();
        x = -250;
        y = 75;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Mover();
	}

    void Mover()
    {
        if (x == -250) { esquerda = true; }
        else if (x == 250) { direita = true; }
        else { direita = false; esquerda = false; }

        if (y == 75) { cima = true; baixo = false; }
        else if (y == -75) { baixo = true; cima = false; }

        if (Input.GetKeyDown("right") && direita == false) { x += 250; }
        else if (Input.GetKeyDown("left") && esquerda == false) { x -= 250; }
        else if (Input.GetKeyDown("up") && cima == false) { y += 75; }
        else if (Input.GetKeyDown("down") && baixo == false) { y -= 75; }
        
    }
}