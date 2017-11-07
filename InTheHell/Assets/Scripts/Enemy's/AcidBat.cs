using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidBat : MonoBehaviour {

    SpriteRenderer sprite;
    public float speedX, speedY;
    Vector3 posYA, posYB, posXD, posXE;
    bool cima, direita;
    GameObject player;

	// Use this for initialization
	void Start ()
    {
		player = Player.playerG;
        sprite = GetComponent<SpriteRenderer>();
        if (player.transform.position.x >= transform.position.x) { direita = false; }
        else if (player.transform.position.x <= transform.position.x) { direita = true; }
        cima = true;
        posXD = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);
        posXE = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);
        posYA = new Vector3(transform.position.x, transform.position.y - 0.75f, transform.position.z);
        posYB = new Vector3(transform.position.x, transform.position.y + 0.75f, transform.position.z);
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Movimentacao();
    }

    void Movimentacao()
    {
        if (direita) { sprite.flipX = false; transform.Translate(Vector2.right * speedX * Time.deltaTime); }
        else { sprite.flipX = true; transform.Translate(Vector2.left * speedX * Time.deltaTime); }

        if (cima)
        {
            transform.Translate(Vector3.up * speedY * Time.deltaTime);
            if (transform.position.y >= posYB.y) { cima = false; }
        }
        else
        {
            transform.Translate(Vector3.down * speedY * Time.deltaTime);
            if (transform.position.y <= posYA.y) { cima = true; }
        }
    }

    void OnCollisionEnter2D(Collision2D colider)
    {
        if (colider.gameObject.tag != "Player") { cima = !cima; }
    }
}