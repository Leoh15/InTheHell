using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chuva : MonoBehaviour {
 
	public int stage;
       
	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Application.loadedLevel == stage) { Destroy(gameObject); }
	}
}