using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeOrbs : MonoBehaviour {

    [SerializeField]
    bool life10, life30;
    float life;
    SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        if (life10) { life = 10; }
        else if (life30) { life = 30; }
    }

    void OnCollisionEnter2D(Collision2D colider)
    {
        if(colider.gameObject.tag == "Player")
        {
            if (Player.life == 100) { Inventario.lifeOrb = true; Destroy(gameObject); }
            else if (Player.life <= 90 && life10) { Player.life += 10; Destroy(gameObject); }
            else if (Player.life <= 70 && life30) { Player.life += 30; Destroy(gameObject); }
            else { life = 100 - Player.life; Player.life += life; Destroy(gameObject); }
        }
    }

}
