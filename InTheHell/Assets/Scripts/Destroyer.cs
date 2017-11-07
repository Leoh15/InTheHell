using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroyer : MonoBehaviour {

    public float tempo;
    public bool gameOver;
    string scene;
	
	// Update is called once per frame
	void Update ()
    {
        tempo -= Time.deltaTime;
        scene = Application.loadedLevelName;

        if(tempo <= 0 && gameOver == false)
        {
            Destroy(gameObject);
        }
        if(gameOver && scene == "GameOver")
        {
            Destroy(gameObject);
        }        	
	}
}