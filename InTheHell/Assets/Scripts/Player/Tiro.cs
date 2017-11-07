using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour {

    public static float velocidade = 8;
    public GameObject flechaDestroyer;
    
	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);
        Destroy(gameObject, 3f);
	}

    void OnCollisionEnter2D(Collision2D colider)
    {
        flechaDestroyer.transform.position = transform.position; Instantiate(flechaDestroyer);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D colider)
    {
        flechaDestroyer.transform.position = transform.position; Instantiate(flechaDestroyer);
        Destroy(gameObject);
    }
}