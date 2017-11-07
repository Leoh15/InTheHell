using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Passagens : MonoBehaviour {

    public GameObject setaCima;
    GameObject player;
    //Vector3 posicaoSetaCima = new Vector3(0, 2, 0); Ainda será usado!
    public Vector3 posicao;
    public int stage;
    bool ativo;

	// Use this for initialization
	void Start ()
    {
//        player = GameObject.FindGameObjectWithTag("Player");
		player = Player.playerG;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Entrar();
	}

    void Entrar()
    {
        if(ativo && Input.GetAxis("Vertical") >0)
        {
            GameObject.DontDestroyOnLoad(player);
            player.transform.position = posicao;
            SceneManager.LoadScene(stage);
        }
    }

    void OnTriggerStay2D(Collider2D colider)
    {
        if(colider.gameObject.tag == "Player")
        {
            ativo = true;
        }
    }

    void OnTriggerEnter2D(Collider2D colider)
    {
        if (colider.gameObject.tag == "Player")
        {
            setaCima.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D colider)
    {
        if (colider.gameObject.tag == "Player")
        {
            setaCima.SetActive(false);
            ativo = false;
        }
    }
}