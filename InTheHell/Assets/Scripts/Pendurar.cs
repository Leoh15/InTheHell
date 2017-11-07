using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendurar : MonoBehaviour {
    
    BoxCollider2D box;
    public Vector2 size;
    Animator playerAnimator;

	// Use this for initialization
	void Start ()
    {
		playerAnimator = Player.playerA;
        box = GetComponent<BoxCollider2D>();		
	}

    void OnTriggerStay2D(Collider2D colider)
    {
        if(colider.gameObject.tag == "Player")
        {
            playerAnimator.SetBool("Pendurado", true);
            box.size = size;
        }
    }

    void OnTriggerExit2D(Collider2D colider)
    {
        if (colider.gameObject.tag == "Player")
        {
            playerAnimator.SetBool("Pendurado", false);
            box.size = new Vector2(0.001f, 0.0397061f);
        }
    }
}