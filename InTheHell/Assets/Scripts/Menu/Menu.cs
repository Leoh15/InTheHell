using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public int scene;
    AudioSource som;
    bool atvTempo;
    float tempo = 1;

	// Use this for initialization
	void Start ()
    {
        som = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.anyKeyDown)
        {
            som.Play();
            atvTempo = true;           
        }

        if (atvTempo)
            tempo = tempo - Time.deltaTime;

        if (tempo <= 0)
        {
            SceneManager.LoadScene(scene);
        }
    }
}