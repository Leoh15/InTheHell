using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour {

    float vida;
    Slider slider;

    // Use this for initialization
    void Start ()
    {
        slider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Life();
	}

    void Life()
    {
        slider.value = Player.life / 100;
    }
}
