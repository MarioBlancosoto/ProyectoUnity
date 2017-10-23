using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {
    [Range(0f,0.30f)]
    public float parallaxSpeed = 0.02f;
    public RawImage background;
    public RawImage platform;
    public GameObject uiIdle;
    public GameObject uiScore;
    public float scaleTime = 6f;
    public float scaleInc = 0.25f;
    public enum GameState {Idle,Playing,Ended };
    public GameState gameState = GameState.Idle;
    public GameObject enemyGenerator;
    private AudioSource musicPlayer;
    private int points = 0;
    public Text pointsText;
    //con esta variable podremos usar los métodos del script PlayerController.
    public GameObject player;
	void Start () {
        musicPlayer = GetComponent<AudioSource>();
		uiScore.SetActive(false);
		resetTimeScale ();
	}

   
	void Update () {
       
        //Comienza el juego y se llama a varios métodos y se activan y desactivan UIs
        if (gameState ==GameState.Idle && (Input.GetKeyDown("up") || Input.GetMouseButtonDown(0)))
        {    gameState = GameState.Playing;
			//ocultamos el texto de cuando el juego está por comenzar
             uiIdle.SetActive(false);
			//mostramos el texto de los puntos al comenzar el juego
             uiScore.SetActive(true);
            //recoge estado y estado de animacíon a la que queremos cambiar
		    //llamada a métodos de estado para que el muñeco comience a correr
            player.SendMessage("UpdateState","PlayerRun");
			//otra llamada a método para que comience el generador de enemigos
            enemyGenerator.SendMessage("startGenerator");
		    //método que inicializa la música
            musicPlayer.Play();
			//método que repite,gameTimeScale,necesario para el aumento progresivo de la velocidad(dificultad) de juego
            InvokeRepeating("gameTimeScale",scaleTime,scaleTime);
        }else if(gameState == GameState.Playing)
        {
			//llamada al efecto parallax del escenario 
            Parallax();
        }else if(gameState == GameState.Ended)
        {
			//si el estado del juego es finalizado,si hacemos click que vuelva a lanzar el inicio del juego con el método
			//restarGame el cual carga la misma escena que inicia el juego
            if (Input.GetKeyDown("up") || Input.GetMouseButtonDown(0))
            {
				//usamos el método restartGame para volver a comenzar el juego al presionar arriba o clikar en el ratón
                restartGame();

            }
        }


       
	}


    public void Parallax()
    {
        float finalSpeed = parallaxSpeed * Time.deltaTime;
        //usamos timedeltatime para que independientemente del procesador vaya fluido
        //los parámetros recogen la posición en cada momento de plataforma y fondo y le aplican velocidad
        platform.uvRect = new Rect(platform.uvRect.x + finalSpeed, 0f, 1f, 1f);
        background.uvRect = new Rect(background.uvRect.x + finalSpeed * 4, 0f, 1f, 1f);

    }


    public void restartGame()
	{	//Añadido a mayores para solucionar el aumento constante de velocidad aún después de finalizar el juego
		//Carga las escena que queramos iniciar
        SceneManager.LoadScene("Principal");
	
		resetTimeScale ();
    }
    public void increasePoints()
    {
        //Usado para incrementar los puntos del uiScore
        points++;
        pointsText.text = points.ToString();
        if (points > 2)
        {
           // SceneManager.LoadScene("fase2");
          

        }
       
    }
    void gameTimeScale()
    {
        Time.timeScale += scaleInc;
    }



    public void resetTimeScale()
    {
		//Reinicia el GameTimeScale y reduce la velocidad a 1f,usado cada vez que el juego se reinicia
        CancelInvoke("gameTimeScale");
        Time.timeScale = 1f;
    }
}
