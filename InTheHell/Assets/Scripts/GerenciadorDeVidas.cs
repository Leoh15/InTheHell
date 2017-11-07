using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenciadorDeVidas : MonoBehaviour {

    public GameObject canvas, chuva, chuvaSound, relampagos;
    public static float life;
    public float lifeShow;
    GameObject player, lifeG;
    Text lifeT;
    public static bool morreu;
    public static Vector3 respawnPosition;

	// Use this for initialization
	void Start ()
    {
        life = 2;
        DontDestroyOnLoad(gameObject);
		player = Player.playerG;
		lifeG = GameObject.Find("Lives"); lifeT = lifeG.GetComponent<Text>(); lifeT.text = "x3";
	}
	
	// Update is called once per frame
	void Update ()
    {
        lifeG = GameObject.Find("Lives"); lifeT = lifeG.GetComponent<Text>(); lifeT.text = "x3";
        lifeShow = life;
        Life();
        Reviver();
	}

    void Reviver()
    {
        if(life > -1 && morreu)
        {
            player.transform.position = respawnPosition;
            //Instantiate(playerPrefab);
            morreu = false;
        }
    }

    void Life()
    {
        if (life == 5)
        {
            lifeT.text = "x5";
        }
        if (life == 4)
        {
            lifeT.text = "x4";
        }
        if (life == 3)
        {
            lifeT.text = "x3";
        }
        else if(life == 2)
        {
            lifeT.text = "x2";
        }
        else if(life == 1)
        {
            lifeT.text = "x1";
            //Heart.gameOver = false;
        }
        else if(life == 0)
        {
            lifeT.text = "x0";
            //Heart.gameOver = true;
        }
        else if(life == -1)
        {
            lifeT.text = "x0";
            Destroy(player);
            Destroy(chuva); Destroy(chuvaSound); Destroy(relampagos); Destroy(canvas);
            Application.LoadLevel(19);
        }
    }
}