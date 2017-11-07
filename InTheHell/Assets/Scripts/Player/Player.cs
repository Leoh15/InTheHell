using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public static GameObject playerG;
	public static Animator playerA;

    //Canvas
        [SerializeField]
        GameObject arcoSelectG, lvlG, kmera;
        public GameObject canvas, update;
        public Button destrezaG, lifeG, velocG;
        [SerializeField]
        Text pontosT, nFlecha, lvlT;
        public Slider experiencia;
    
    //Componentes
    //Public's
        public AudioClip sword1, sword2, arrow, pegarItem, caiu;
        public Animator animator; //Animator do Player
        public GameObject tiroD, tiroE, playerMorte, pingosAgua, inventarioG, pauseG;
        public SpriteRenderer sprite; //SpriteRenderer do player
        public Transform objetoParaSeguir; //Transform usado pela câmera para "seguir" o player 

    //Static
        public static bool esquerda, direita, pular, trocar, atacar; //Android
        public static int numeroFlechas, pontos;
        public static float life = 100, lifeFor;
        public static bool matou, pausar;

    //Private's
        AudioSource som;
        //GameObject ;
        Rigidbody2D rb; //Rigidbody do player
        BoxCollider2D[] box; //BoxColliders(2) do player

    //Variáveis
        //Public's
        public bool ataqueArco, ataqueEspada, ativarTempo, ativo, D, DC, E, EC, pulou, seguir, pendurou; //Bool's
        public Vector2 dObjeto, pulo; //Vector2's
        public static int heartsN;

    //Privates
        int lvl, lvlAtual;
        public static float velocidade = 3.5f;
        float tempo = 0.5f, tempoDano = 3, valorExp,danoF, velocEspada, lvlVeloc, lvlDestreza, lvlLife;
        Vector3 respawn;
        bool morreu, parou, dano, arco, pause, lvlPass, submerso, inventario;
        Vector3 distanciaDn, distanciaEn;
        string stage;

    // Use this for initialization
    void Start ()
    {
		playerA = gameObject.GetComponent<Animator> ();
		playerG = this.gameObject;
        lvl = 1;
        Physics2D.IgnoreLayerCollision(11, 9, false);
        velocEspada = 0.6f;
        animator.speed = 0.6f;
        lifeFor = life;
        danoF = 35f;
        valorExp = 0.1f;
        stage = Application.loadedLevelName;
        DontDestroyOnLoad(gameObject);
        GameObject.DontDestroyOnLoad(canvas);
        som = GetComponent<AudioSource>();
        arco = false;
        D = true;
        numeroFlechas = 5;
        arcoSelectG.SetActive(false);
        lvlT = lvlG.GetComponent<Text>(); lvlT.text = "Level : "+ lvl;
        seguir = true;
        heartsN = 3;
        box = GetComponents<BoxCollider2D>(); //Collider's do player
        rb = GetComponent<Rigidbody2D>(); //Rigidbody do player
        pulou = false; //Player começa sem pular
        nFlecha.text = "x" + numeroFlechas;
    }

    void Update()
    {
        pontosT.text = "Pontos : " + pontos;
        
        MostrarInventario();
        CronometroAtaque();
        Pause();
        Pulo();
        TrocarArma();
        if (ataqueArco) { AtacarArco(); }
        if (ataqueEspada) { AtacarEspada(); }
        Dano();
        Exp();
    }

	// Update is called once per frame
	void FixedUpdate ()
    {
        if (stage != Application.loadedLevelName) { sprite.enabled = true; stage = Application.loadedLevelName; }

        Mecanicas();
        Morrer();
    }

    public void Direita() { direita =! direita; }
    public void Esquerda() { esquerda = !esquerda; }
    public void Pular() { pular =! pular; }
    public void Atacar() { atacar =! atacar; }
    public void Switch() { trocar = !trocar; }

    void MostrarInventario()
    {
        if (inventario == false && Input.GetButtonDown("Submit")) { inventarioG.SetActive(true); velocidade = 0; inventario = true;  }
        else if (inventario == true && Input.GetButtonDown("Submit")) { inventarioG.SetActive(false); velocidade = lvlVeloc * .5f + 4   ; inventario = false; }
    }

    public void Vida() { lvlLife++; danoF -= 10; update.SetActive(false);
        if(lvlLife == 3)
        {
            lifeG.interactable = false;
        }
        Time.timeScale = 1;
    }
    public void Destreza() { lvlDestreza++; velocEspada += 0.2f; Tiro.velocidade += 5; update.SetActive(false);
        if (lvlDestreza == 2)
        {
            destrezaG.interactable = false;
        }
        Time.timeScale = 1;
    }
    public void Velocidade() { lvlVeloc++; velocidade += 0.5f; update.SetActive(false);
        if (lvlVeloc == 3)
        {
            velocG.interactable = false;
        }
        Time.timeScale = 1;
    }

    public void Exp()
    {
        if(matou)
        {
            experiencia.value += valorExp;
            matou = false;
        }
        if(experiencia.value == 1 && lvl != 6)
        {
            Time.timeScale = 0;
            lvl++;
            lvlT.text = "Level : " + lvl;
            life = 100;
            if (lvl < 6) { experiencia.value = experiencia.value - 1; }
            else { lvlT.text = "Level Max"; }
            valorExp -= 0.02f;
            update.SetActive(true);
        }
    }

    void Pause()
    {
        if(Input.GetKeyDown(KeyCode.P) && pause == false)
        {
            Time.timeScale = 0;
            pauseG.SetActive(true);
            pause = true;
        }
        else if(Input.GetKeyDown(KeyCode.P) && pause)
        {
            Time.timeScale = 1;
            pauseG.SetActive(false);
            pause = false;
        }
    }

    void Dano()
    {
        if(dano)
        {
            Physics2D.IgnoreLayerCollision(11,9,true);

            tempoDano -= Time.deltaTime;

            if (tempoDano <= 0)
            {
                sprite.enabled = true;
                Physics2D.IgnoreLayerCollision(11, 9, false);
                dano = false;
                tempoDano = 2;
            }
            if (tempoDano <= 2)
                sprite.enabled = true;
            if (tempoDano <= 1.75)
                sprite.enabled = false;
            if (tempoDano <= 1.5)
                sprite.enabled = true;
            if (tempoDano <= 1.25)
                sprite.enabled = false;
            if (tempoDano <= 1)
                sprite.enabled = true;
            if (tempoDano <= 0.75)
                sprite.enabled = false;
            if (tempoDano <= 0.5)
                sprite.enabled = true;
            if (tempoDano <= 0.25)
                sprite.enabled = false;
        }
    }

	void Morrer()
	{
        if (/*heartsN == 0*/ life <= 0)
        {
            Physics2D.IgnoreLayerCollision(11, 9, false); dano = false; tempoDano = 2;
            GerenciadorDeVidas.morreu = true; /*Heart.morreu = true;*/ Kmera.morreu = true;
            GerenciadorDeVidas.life--;
            playerMorte.transform.position = transform.position;
            Instantiate(playerMorte);
            //heartsN = 3;
            life = 100;
        }

        if (morreu) 
		{
			transform.position = respawn;
			morreu = false;
		}
	}
    
    // Mecânicas do player
    void Mecanicas()
    {
        animator.SetFloat("Velocidade", 0); //Setando a animação inicial
        
        //Andar para a direita
        if (Input.GetAxis("Horizontal") > 0 && pausar == false || direita)
        {
            if(seguir){DC = true; EC = false;}
            D = true; E = false;
            if (pendurou == false) { animator.SetFloat("Velocidade", 1); }
            sprite.flipX = false;
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
        }
        //Andar para a esquerda
        else if (Input.GetAxis("Horizontal") < 0 && pausar == false || esquerda)
        {
            if(seguir){EC = true; DC = false;}
            sprite.flipX = true;
            E = true; D = false;
            if (pendurou == false) { animator.SetFloat("Velocidade", 1); }
            transform.Translate(Vector2.left * velocidade * Time.deltaTime);
        }
    }

    void Pulo()
    {
        //Condição para pular
        if (pulou == false && Input.GetButtonDown("Jump") || pulou == false && pular)
        {
            pulou = true; //Está pulando
            animator.SetBool("Pulo", true);
            rb.velocity = pulo;
        }
    }
 
    void TrocarArma()
    {
        if (arco) { arcoSelectG.SetActive(false); arco = false; }

        if (Input.GetKeyDown("tab") || Input.GetButtonDown("Fire3") || trocar)
        {
            if (ataqueArco) { arcoSelectG.SetActive(false); ataqueArco = false; ataqueEspada = true; }
            else if (ataqueEspada) { arcoSelectG.SetActive(true); ataqueEspada = false; ataqueArco = true; }
            trocar = false;
        }
    }

    void CronometroAtaque()
    {
        if (ativarTempo == true) { tempo = tempo - Time.deltaTime; } //Condição para início do contador de tempo
        if (tempo <= 0) // tempo acabou e o player "recupera" suas habilidades 
        {
            animator.speed = 1;
            velocidade = 3.5f + 0.5f * lvlVeloc;
            ativo = false; // poderá atacar novamente
            ativarTempo = false; // O contador para
            tempo = 0.5f; // O cronômetro é parado e é restabelecido o tempo para o próximo ataque(loop)
        }
    }

    // A.A - Método responsável pelo ataque(com espada) do player
    void AtacarEspada() 
    {
        if (ataqueEspada == true && pendurou == false) //Player poderá trocar, podendo estar ativada ou desativada
            if (ativo == false) // Variável usada como ponte de permissão para o ataque, utilizada tanto no A.E quanto no A.A 
				if (Input.GetKeyDown ("q") || Input.GetButtonDown("Fire2") || atacar)
                {
                    animator.speed = velocEspada;
                    int ataqueAleatorio = Random.Range(1, 3);
                    if (ataqueAleatorio == 1) { som.clip = sword1; som.Play(); }
                    else { som.clip = sword2; som.Play(); }

                    if (pulou == false){ velocidade = 0;}

                    ativo = true; //Player está atacando    
					ativarTempo = true; //Player só poderá atacar novamente quando esse tempo acabar

                    if (D){ animator.SetTrigger("AtaqueE"); /*Animação de ataque*/ }
                    else { animator.SetTrigger("AtaqueD"); }
		     	}   
    }
    
    // A.A - Método responsável pelo ataque(com arco) do player
    void AtacarArco()
    {
        nFlecha.text = "x" + numeroFlechas;
        Vector3 distanciaD = new Vector3(0.75f, -0.2f, 0); // Distância de spawn da fecha direita
        Vector3 distanciaE = new Vector3(-0.75f, -0.2f, 0); // Distância de spawn da fecha esquerda

        tiroD.transform.position = objetoParaSeguir.position + distanciaD; //Posição das fechas para evitar que elas sejam geradas dentro do player(Player + distancia).
        tiroE.transform.position = objetoParaSeguir.position + distanciaE;
        
        if (ataqueArco == true && numeroFlechas > 0 && pendurou == false) // Player poderá trocar, podendo estar ativada ou desativada
            if (D == true) //Direção da flecha que é trocada no void "Mecanicas" (direita)
            { 
                if (ativo == false) //Condição para o ataque
                    if (Input.GetKey("q") || Input.GetButtonDown("Fire2") || atacar) //Gatilho
                    {
                        som.clip = arrow;
                        som.Play();
                        numeroFlechas--;
                        nFlecha.text = "x" + numeroFlechas; 
                        ativo = true; //Condição desativada, impedindo novos ataques
                        ativarTempo = true; // tempo para outro ataque
                        animator.SetTrigger("AtaqueArco"); // Animação do player com arco
                        Instantiate(tiroD); // É instanciada uma fecha utilizando a linha 147
                    }
            }
            else if(E)
            {
                if (ativo == false) //Condição para o ataque
                    if (Input.GetKey("q") || Input.GetButtonDown("Fire2") || atacar) //Gatilho
                    {
                        som.clip = arrow;
                        som.Play();
                        numeroFlechas--;
                        ativo = true; // Condição desativada
                        ativarTempo = true; //Tempo para outro ataque
                        animator.SetTrigger("AtaqueArco"); // Animação do player com arco
                        Instantiate(tiroE); // É instanciada uma flecha utilizando a linha 148
                    }
            }

        atacar = false;
    }    

    // Colisão de objetos
    void OnCollisionEnter2D(Collision2D colider)
    {
        animator.SetBool("Pulo", false);
        velocidade = 4 + 0.5f * lvlVeloc;

        if (colider.gameObject.tag == "Life")
        {
            som.clip = pegarItem;
            som.Play();
            GerenciadorDeVidas.life++;
            Destroy(colider.gameObject);
        }

        if (colider.gameObject.tag == "Plataforma" || colider.gameObject.tag == "Pendurar") // Se ele estiver colidindo é porque esta no chão, ou seja, poderá pular novamente
        {
            pendurou = false;
            pulou = false; //É aqui onde desativamos o "pulou"            
        }

        if(colider.gameObject.tag == "Enemy")
        {
            life -= danoF;
            heartsN--;
            dano = true;
        }

        if(colider.gameObject.tag == "Armadilha")
        {
            life -= danoF;
            playerMorte.transform.position = transform.position;
            Instantiate(playerMorte);
            heartsN--;
            morreu = true;
            dano = true;
        }

        if (colider.gameObject.tag == "Mata") // Se colidir com algo com a tag "Mata" o objeto é destruido
        {
            GerenciadorDeVidas.life--;
            life = 100;
            //heartsN = 3;
            playerMorte.transform.position = transform.position;
            Instantiate(playerMorte);
            morreu = true;
            dano = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D colider)
    {
        if (colider.gameObject.tag == "Agua" && submerso) { submerso = false; velocidade +=1.5f;  pingosAgua.transform.position = transform.position + new Vector3(0, -.25f, 0); Instantiate(pingosAgua); }
    }

    void OnTriggerStay2D(Collider2D colider)
    {
        if (colider.gameObject.tag == "Pass") { stage = Application.loadedLevelName; }
        if (colider.gameObject.tag == "Pass" && Input.GetAxis("Vertical") > 0) { sprite.enabled = false; }
        if (colider.gameObject.tag == "Pendurar" && colider.gameObject.transform.position.y >= transform.position.y - 0.75) { pendurou = true; }
    }

    void OnCollisionStay2D(Collision2D colider)
    {
        if (colider.gameObject.tag == "Pendurar" && colider.gameObject.transform.position.y >= transform.position.y - 0.75)
        {
            pendurou = true;
        }
    }

    // Colisão de objetos no TriggerMode
    void OnTriggerEnter2D(Collider2D colider)
    {
        if (colider.gameObject.tag == "Agua" && submerso == false) { submerso = true; velocidade -=1.5f; pingosAgua.transform.position = transform.position + new Vector3(0,-.65f,0); Instantiate(pingosAgua); }

        if (colider.gameObject.name == "LifeRespawn") { GerenciadorDeVidas.respawnPosition = colider.transform.position; }

        if (colider.gameObject.tag == "Mata") // Se colidir com algo com a tag "Mata" o objeto é destruido
        {
            playerMorte.transform.position = transform.position;
            Instantiate(playerMorte);
            heartsN--;
            morreu = true;
            dano = true;
        }

        //Respawn do player
        if (colider.gameObject.tag == "R") { respawn = colider.transform.position; }

        if (colider.tag == "D" || colider.tag == "E") //Ao bater nesse PassStage, a câmera virá posicionada na direita
        {
            stage = Application.loadedLevelName;
            sprite.enabled = false;
        }
    }

    void OnCollisionExit2D(Collision2D colider)
    {
        if (colider.gameObject.tag == "Pendurar") { pendurou = false; }
    }
}