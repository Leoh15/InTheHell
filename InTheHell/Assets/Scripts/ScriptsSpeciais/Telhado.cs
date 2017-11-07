using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telhado : MonoBehaviour {

    public float tempoA, tempoB;
    public GameObject edge;
    public bool ativo;

	// Use this for initialization
	void Start ()
    {
        tempoA = Random.Range(0, 0.01f);
        tempoB = Random.Range(0, 0.01f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        Calha();
	}

    void Calha()
    {
        tempoA -= Time.deltaTime;

        if(tempoA <= 0)
        {
            ativo = true;
            edge.SetActive(false);

            tempoB -= Time.deltaTime;

            if(tempoB <= 0)
            {
                ativo = false;
                edge.SetActive(true);
                tempoA = Random.Range(0, 0.02f);
                tempoB = Random.Range(0, 0.1f);
            }
        }
    }
}