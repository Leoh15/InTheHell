using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    public static float slots;

    [SerializeField]
    GameObject[] slotsSpace = new GameObject[6], popUps = new GameObject[2];
    [SerializeField]
    GameObject select;

    float time;
    int posicoes;
    public static bool um, dois, tres, quatro, cinco, seis;
    bool umP, doisP, tresP, quatroP, cincoP, seisP;
    public static bool flechas, lifeOrb;

    Transform rect;

    Vector3 position;

    [SerializeField]
    Image flechasS, lifeOrbS;
    
    void Start()
    {
        um = true; umP = true;
        dois = true; doisP = true;
        tres = true; tresP = true;
        posicoes = 1;
    }

    void Update()
    {
        MoverSelect();
        Add();
    }

    void MudarSpace()
    {
        if (um == false) { um = true; umP = false; }
        else if (dois == false) { dois = true; doisP = false; }
        else if (tres == false) { tres = true; tresP = false; }
        else if (quatro == false) { quatro = true; quatroP = false; }
        else if (cinco == false) { cinco = true; cincoP = false; }
        else if (seis == false) { seis = true; seisP = false; }
    }

    void Add()
    {
        if (lifeOrb)
        {
            MudarSpace();
            SetarPosicao();
            Instantiate(popUps[0], transform);
            Instantiate(lifeOrbS, rect);
            lifeOrb = false;
        }
        else if(flechas)
        {
            MudarSpace();
            SetarPosicao();
            Instantiate(popUps[1], transform);
            Instantiate(flechasS, rect);
            flechas = false;
        }
    }

    void SetarPosicao()
    {
        if(lifeOrb)
        {
            if (um && umP == false) { rect = slotsSpace[0].transform; lifeOrbS.name = "um"; umP = true; }
            else if (dois && doisP == false) { rect = slotsSpace[1].transform; lifeOrbS.name = "dois"; doisP = true; }
            else if (tres && tresP == false) { rect = slotsSpace[2].transform; lifeOrbS.name = "tres"; tresP = true; }
            else if (quatro && quatroP == false) { rect = slotsSpace[3].transform; lifeOrbS.name = "quatro"; quatroP = true; }
            else if (cinco && cincoP == false) { rect = slotsSpace[4].transform; lifeOrbS.name = "cinco"; cincoP = true; }
            else if (seis && seisP == false) { rect = slotsSpace[5].transform; lifeOrbS.name = "seis"; seisP = true; }
        }
        else if(flechas)
        {
            if (um && umP == false) { rect = slotsSpace[0].transform; flechasS.name = "um"; umP = true; }
            else if (dois && doisP == false) { rect = slotsSpace[1].transform; flechasS.name = "dois"; doisP = true; }
            else if (tres && tresP == false) { rect = slotsSpace[2].transform; flechasS.name = "tres"; tresP = true; }
            else if (quatro && quatroP == false) { rect = slotsSpace[3].transform; flechasS.name = "quatro"; quatroP = true; }
            else if (cinco && cincoP == false) { rect = slotsSpace[4].transform; flechasS.name = "cinco"; cincoP = true; }
            else if (seis && seisP == false) { rect = slotsSpace[5].transform; flechasS.name = "seis"; seisP = true; }
        }
    }

    void MoverSelect()
    {
        time -= Time.deltaTime;

        if(time <= 0)
        {
            if (Input.GetAxis("Horizontal") > 0 && posicoes == 1 || Input.GetAxis("Horizontal") > 0 && posicoes == 2 || Input.GetAxis("Horizontal") > 0 && posicoes == 4 || Input.GetAxis("Horizontal") > 0 && posicoes == 5) { posicoes++; }
            if (Input.GetAxis("Horizontal") < 0 && posicoes == 3 || Input.GetAxis("Horizontal") < 0 && posicoes == 2 || Input.GetAxis("Horizontal") < 0 && posicoes == 5 || Input.GetAxis("Horizontal") < 0 && posicoes == 6) { posicoes--; }
            if (Input.GetAxis("Vertical") > 0 && posicoes == 4 || Input.GetAxis("Vertical") > 0 && posicoes == 5 || Input.GetAxis("Vertical") > 0 && posicoes == 6) { posicoes -= 3; }
            if (Input.GetAxis("Vertical") < 0 && posicoes == 1 || Input.GetAxis("Vertical") < 0 && posicoes == 2 || Input.GetAxis("Vertical") < 0 && posicoes == 3) { posicoes += 3; }

            if (posicoes == 1) { select.transform.position = slotsSpace[0].transform.position; }
            else if (posicoes == 2) { select.transform.position = slotsSpace[1].transform.position; }
            else if (posicoes == 3) { select.transform.position = slotsSpace[2].transform.position; }
            else if (posicoes == 4) { select.transform.position = slotsSpace[3].transform.position; }
            else if (posicoes == 5) { select.transform.position = slotsSpace[4].transform.position; }
            else if (posicoes == 6) { select.transform.position = slotsSpace[5].transform.position; }

            time = 0.2f;
        }
    }
}