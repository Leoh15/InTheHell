using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaItem : MonoBehaviour {

    public GameObject gO;
    public bool ativo, andar, monster, mover;
    public Vector3 distancia;

    void Mover()
    {
        if (ativo == true)
        {
            if (mover == true)
            {
                gO.transform.position = distancia;
                Destroy(gameObject);
                Destroy(gO, 2);
            }
            else if(andar == true)
            {
                gO.transform.Translate(distancia);
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D colider)
    {
        if (colider.gameObject.tag == "Player")
        {            
            ativo = true;
            Mover();
        }
    }
}