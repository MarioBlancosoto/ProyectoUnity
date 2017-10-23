using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject game;
    private Animator animator;
    public GameObject enemyGenerator;
    private AudioSource audioPlayer;
    public AudioClip jumpClip;
    public AudioClip dieClip;
    private float startY;

    void Start () {
        animator = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
        startY = transform.position.y;
    }
	
	
	void Update () {
		/*isgrounded Recoge la posición exacta de Y del muñeco cuando está sobre la plataforma.usamos esto para evitar
		 * saltar desde cualquier otra posición
         */
        bool isgrounded = transform.position.y == startY;
		//este otro boleano recoge si el estado del juego es jugando y le asigna un true
        bool gamePlaying = game.GetComponent<GameController>().gameState == GameController.GameState.Playing;
		/*la condición nos permite saber si el el player está en el suelo o jugando o después de haber empezado el juego
         Esto nos permitiría saltar,que suene el audio del salto cuando se produzca el salto y que comience la música del juego*/
	if(isgrounded && gamePlaying && (Input.GetKeyDown("up") || Input.GetMouseButtonDown(0)))
        {
            UpdateState("PlayerJump");
            audioPlayer.clip = jumpClip;
            audioPlayer.Play();
        }
	}


    public void UpdateState(string state = null)
    {
        if (state != null)
        {
            animator.Play(state);
        }
    }

	/*usado para reconocer la colisión con el enemigo,si el tag es igual al del objeto enemigo
      actualizamos el estado del player y pasa a PlayerDie
      pasamos el estado del juego a Ended
      se ejecutan los audios de cuando el jugador muere
      */
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
           
            UpdateState("PlayerDie");
            game.SendMessage("gameTimeScale");
            game.GetComponent<GameController>().gameState = GameController.GameState.Ended;
            enemyGenerator.SendMessage("cancelGenerator");
            game.GetComponent<AudioSource>().Stop();
            audioPlayer.clip = dieClip;
            audioPlayer.Play();
        }
		/*si el tag con el que colisiona el player es igual a point,se llama al método increasePoints el cual
		 incrementa los puntos en 1 unidad*/
        else if((other.gameObject.tag == "point"))
        {
            game.SendMessage("increasePoints");
        }
    }
}
