using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantasminha : MonoBehaviour {

    GameObject player;
    public float velocidade;
    SpriteRenderer sprite;
    BoxCollider2D box;

	// Use this for initialization
	void Start ()
    {
        box = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
		player = Player.playerG;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Movimentar();
	}

    void Movimentar()
    {
        if (player.transform.position.x > transform.position.x)
        {
            sprite.flipX = true;
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
        }
        if (player.transform.position.x < transform.position.x)
        {
            sprite.flipX = false;
            transform.Translate(Vector2.left * velocidade * Time.deltaTime);
        }
        if (player.transform.position.y > transform.position.y)
        {
            transform.Translate(Vector2.up * velocidade * Time.deltaTime);
        }
        if (player.transform.position.y < transform.position.y)
        {
            transform.Translate(Vector2.down * velocidade * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D colider) { box.isTrigger = true; }

    void OnTriggerEnter2D(Collider2D colider)
    {
        box.isTrigger = false;

        if(colider.gameObject.tag == "Player")
        {
            velocidade = 0;
        }
    }
}