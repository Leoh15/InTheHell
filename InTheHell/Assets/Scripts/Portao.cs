using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portao : MonoBehaviour {

    BoxCollider2D box;
    Animator portaoAnimator;
    public Vector2 pos1, pos2, pos3, fechar;
    [SerializeField]
    GameObject player;
    public GameObject portao, boss, portaoUi;
    public bool botao1, botao2, botao3, especial, portaoB;

    // Use this for initialization
    void Start()
    {
        boss.transform.position = new Vector3(-3.311983f, 0.5084101f, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        AtivarBotao();
        FecharPortao();
	}

    void AtivarBotao()
    {
        string stage = Application.loadedLevelName;

        if (stage == "Cena8.1" && player.transform.position.x >= pos1.x) {botao1 = true;}
        if (stage == "Cena8.2" && player.transform.position.x >= pos2.x) {botao2 = true;}
        if (stage == "Cena8.3" && player.transform.position.x >= pos3.x) {botao3 = true;}
        if (stage == "Cena8" || stage == "Cena8.3")
        {
            if (botao1 && botao2 && botao3)
            {
                portao = GameObject.Find("Portao");
                portaoAnimator = portao.GetComponent<Animator>();
                portaoAnimator.SetBool("Desceu", true);
                box = portao.GetComponent<BoxCollider2D>();
                Destroy(box);
            }
        }
        if (especial && player.transform.position.x >= pos1.x) { botao1 = true; botao2 = true; botao3 = true; }

    }

    void FecharPortao()
    {
        if(portaoB && player.transform.position.x >= fechar.x)
        {
            portaoAnimator = GetComponent<Animator>();
            portaoAnimator.SetBool("Abriu", true);
            portaoUi.SetActive(true);
            Instantiate(boss);
            portaoB = false;
        }
    }
}