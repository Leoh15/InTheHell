using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class Relampagos : MonoBehaviour 
{
    public GameObject luz;
	public float tempo, tempoMetodo;
	bool ativo, atvTempo, metodoB, metodoNB;
    public int metodo;

	// Use this for initialization
	void Start ()
	{
        tempoMetodo = Random.Range(5, 9);
        atvTempo = true;
        tempo = 1;
	}

	// Update is called once per frame

	void Update ()
	{
        if(metodoB == false) { tempoMetodo -= Time.deltaTime; }

        if (tempoMetodo <= 0)
        {
            if(metodoNB == false) { metodo = Random.Range(1, 5); metodoNB = true; }

            if (metodo == 1 || metodo == 2 || metodo == 3) {Relampago(); }
            else if (metodo == 4) { RelampagoDuplo(); }
        }
	}

	void Relampago()
	{
        tempo -= Time.deltaTime;
        luz.SetActive(true);

        if(tempo <= 0.5)
        {
            luz.SetActive(false);
            metodoNB = false; tempo = 1f; metodoB = false; tempoMetodo = Random.Range(5, 9);
        }
	}

    void RelampagoDuplo()
    {
        tempo -= Time.deltaTime;
        luz.SetActive(true);

        if(tempo <= 0.75){luz.SetActive(true);}

        if (tempo <= 0.5){luz.SetActive(false);}

        if (tempo <= 0.25) { luz.SetActive(true); }

        if (tempo <= 0)
        {
            luz.SetActive(false);
            tempo = Random.Range(1, 3);
            atvTempo = false;
            metodoNB = false; tempo = 1; metodoB = false; tempoMetodo = Random.Range(5, 9);
            ativo = true;
        }
    }
}