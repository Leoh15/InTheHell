using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassCena : MonoBehaviour {

	GameObject player;
    public Vector3 position;
    public int stage; // Marca para qual cena queremos ir
    public bool cronometro, skip, passar;
    public float tempo, tempoT = 1;

	void Start()
	{
        player = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void FixedUpdate ()
    {
        Skip();

        if(cronometro)
        {
            tempo -= Time.deltaTime;

            if(tempo <= 0)
            {
                SceneManager.LoadScene(stage);
            }
        }
	}

    void Skip()
    {
        if(skip && Input.anyKeyDown)
        {
            SceneManager.LoadScene(stage);
        }
    }

    void OnTriggerEnter2D(Collider2D colider)
    {
        if (colider.gameObject.tag == "Player" || colider.gameObject.name == "Player(Clone)")
        {
            SceneManager.LoadScene(stage); // Quando o player colidir neste objeto, o script carrega a cena colocada na variável "stage"
			player.transform.position = position;
        }
    }
}