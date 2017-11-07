using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PO : MonoBehaviour {

    public float time, timeNow, velocidade;
    public bool direita;
    SpriteRenderer sprite;

	// Use this for initialization
	void Start ()
    {
        timeNow = time;
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        MudarDireção();
        MovX();
	}

    void MovX()
    {
        if(direita)
        {
            sprite.flipX = false;
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
        }
        else
        {
            sprite.flipX = true;
            transform.Translate(Vector2.left * velocidade * Time.deltaTime);
        }
    }

    void MudarDireção()
    {
        timeNow -= Time.deltaTime;

        if(timeNow <= 0)
        {
            if(direita)
            {
                direita = false; 
            }
            else
            {
                direita = true;
            }

            timeNow = time;
        }
    }
}