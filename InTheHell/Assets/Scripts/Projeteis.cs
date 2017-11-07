using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projeteis : MonoBehaviour {

    public GameObject explosion;
    public float time;
    public bool fireBall, instanciou;

	void Update ()
    {
        time = time - Time.deltaTime;

        if (time <= 0)
        {
            if(fireBall && instanciou == false)
            {
                instanciou = true;
                explosion.transform.position = transform.position;
                Instantiate(explosion);
            }
            Destroy(gameObject);
        }
	}
}