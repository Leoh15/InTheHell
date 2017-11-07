using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {
        
    public int heartsN;
    public GameObject heart1, heart2, heart3;
    GameObject playerG;
    public static bool morreu, gameOver;

	// Use this for initialization
	void Start ()
    {
		heartsN = Player.heartsN;
        heart1 = GameObject.Find("0");
        heart2 = GameObject.Find("1");
        heart3 = GameObject.Find("2");
    }
	
	// Update is called once per frame
	void Update ()
    {
        Coracao();
    }

    void PlayerReviver()
    {
        if(morreu)
        {
            heart1 = GameObject.Find("0");
            heart2 = GameObject.Find("1");
            heart3 = GameObject.Find("2");
            Player.heartsN += 3;
            morreu = false;
        }
    }

    void Coracao()
    {
        heartsN = Player.heartsN;

        if (GerenciadorDeVidas.life == -1)
        {
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }
        else if (Player.heartsN == 3)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
        }
        else if (Player.heartsN == 2)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(false);
        }
        else if (Player.heartsN == 1)
        {
            heart1.SetActive(true);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }
        else if (Player.heartsN == 0)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
        }
    }
}