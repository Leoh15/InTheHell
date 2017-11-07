using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kmera : MonoBehaviour
{
    public float distanciaMinP, distanciaMaxP, distanciaMinC, distanciaMaxC;
    public bool direita;
	[SerializeField]
    GameObject player;
    public bool seguir, parou;
    public static bool s61;
    int n = 0;
    public static bool morreu;
    string cena;

	void Start(){ player = Player.playerG; }

    void Update()
    {
		if (player == null) { player = Player.playerG; }
        PosicoesEspeciais();
        
        PlayerAtributos();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CameraMove();
        CameraSeguir();
    }

    void PosicoesEspeciais()
    {
        cena = Application.loadedLevelName;

        if (cena == "Cena6.1") { s61 = true; }
        if (cena == "Cena6" && s61) { transform.position = player.transform.position; s61 = false; }
    }

    void CameraMove()
    {
        if (transform.position.x > distanciaMaxC && player.transform.position.x > distanciaMaxP)
        {
            parou = true;
            seguir = false;
        }
        else if (transform.position.x < distanciaMinC && player.transform.position.x < distanciaMinP)
        {
            parou = true;
            seguir = false;
        }
        else if (player.transform.position.x < distanciaMaxP && player.transform.position.x > distanciaMinP)
        {
            seguir = true;
        }
    }

    void CameraSeguir()
    {
        Vector3 posicionD = new Vector3(3, 0, -9);
        Vector3 posicionE = new Vector3(-3, 0, -9);
        Vector3 posicionP = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);

        if (seguir == true) //Condição para seguir
        {
            if (direita) //Direita ou esquerda?
                transform.position = Vector3.Lerp(transform.position, player.transform.position + posicionD, 0.025f); //0.035f
            else if (direita == false) //Direita ou esquerda
                transform.position = Vector3.Lerp(transform.position, player.transform.position + posicionE, 0.025f);
        }
        else { transform.position = Vector3.Lerp(transform.position, posicionP, 0.025f); }
    }

    void PlayerAtributos()
    {
        if (Input.GetAxis("Horizontal") > 0 || Player.direita)
            direita = true;

        if (Input.GetAxis("Horizontal") < 0 || Player.esquerda)
            direita = false;
    }
}