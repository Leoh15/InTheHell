using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luz : MonoBehaviour {

    Light[] luz;
    public float distance;
    GameObject player;

	// Use this for initialization
	void Start ()
    {
		player = Player.playerG;
        luz = GetComponentsInChildren<Light>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        ApagarAcender();
	}

    void ApagarAcender()
    {
        distance = Vector2.Distance(player.transform.position, transform.position);

        if (distance >= 10)
        {
            luz[0].gameObject.SetActive(true);
        }
        else
        {
            luz[0].gameObject.SetActive(true);
        }
    }
}