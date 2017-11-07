using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peixe : MonoBehaviour {

    float velocidade = 2.5f, tempo = 5, tempoCollision = 1;
    Rigidbody2D rb;
    [SerializeField]
    Vector2 pulo;
    SpriteRenderer sprite;
    /*[SerializeField]
    GameObject particles;*/
    [SerializeField]
    bool vertical, horizontal, direita;
    GameObject player;

	// Use this for initialization
	void Start ()
    {
		player = Player.playerG;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        if (vertical) { rb.velocity = pulo; }
        else if (player.transform.position.x > transform.position.x) { direita = false; }
        else { direita = true; }
	}
	
    void Update()
    {
        if (vertical)
        {
            tempo -= Time.deltaTime;

            if (tempo <= 4)
            {
                sprite.flipY = true;
            }
            if (tempo <= 0)
            {
                Destroy(gameObject);
            }
        }
        else if(horizontal)
        {
            if (direita) { sprite.flipY = true; transform.Translate(Vector3.down * velocidade * Time.deltaTime); }
            else { sprite.flipY = false; transform.Translate(Vector3.up * velocidade * Time.deltaTime); }
        }
    }

    void OnCollisionEnter2D(Collision2D colider)
    {
        if (horizontal) { direita = !direita; }
    }

    void OnTriggerEnter2D(Collider2D colider)
    {
        if (colider.tag == "Player") { velocidade *= -1; }

        //if (colider.gameObject.name == "RioCollider" && (particles)) { particles.transform.position = transform.position; Instantiate(particles); }
    }
}