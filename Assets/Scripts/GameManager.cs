using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    private int puntos;//Creo una clase privada para guardar la puntuacion del jugador 
    [SerializeField]private GameObject Contador;//El contador sirve para saber cuantas tuberias ha pasado  
    [SerializeField]private GameObject Score;//La puntuacion que ha hecho el jugador dentro del juego
    [SerializeField] private GameObject SmaxCore;//La puntuacion maxima que ha hecho el jugador dentro del juego siempre esta guardada la puntuacion
    private int maxScore;//La puntuacion inicial si el jugador no ha jugado ninguna partida
  

    
    public  enum Estado{Start,Game,Rate,ScoreBoard,Pause,GameOver};//Los distintos estados que tiene el juego 
    //Las distintas interfaces del juego 
    public  Estado estadoactual;
    //La interfaz actual que se encuentra el jugador dentro del juego 
    
    
    public delegate void SoundChoque(int sonido);
    public static event SoundChoque onSoundChoque;
    //Delegado y evento para activar el sonido concreto dentro del juego 
    public delegate void UpdateGameState(Estado e);
    public static event UpdateGameState onUpdateGameState;
    //Delegado y evento para el cambio de estado 
    

    public delegate void SoundMenu(int sonido);

    public static event SoundMenu onSounMenu;
    private void Awake()
    {
        Pajaro.OnLaunchRestar += RestartGame;//Escuchar llamada cuando ya esta lanzada 
        Goal.onIncreasepoint += IncreasePoints;//Incrementa la puntuacion dentro del juego 
        
        //Contador = GameObject.Find("Contador");
        //SmaxCore = GameObject.Find("MaxScore");
        //Score = GameObject.Find("Score");
        
        
        
        //Comprobamos que exita una puntuacion maxima registrada 
        //Si no la tiene la ponemos a 0
        maxScore = 0;
        if (PlayerPrefs.GetInt("MaxScore")!=0)
        {
            Debug.Log("maxprefs tienen algo");
            maxScore = GetMaxScore();
           
        }
     ///Actualizamos el contenerdor
     ///  De la interfaz ScoreBoard
     SmaxCore.GetComponent<TextMeshProUGUI>().text = maxScore.ToString();
    

    }

    void Start()
    {
        estadoactual = Estado.Start;
        puntos = 0;//Puntos del jugador inicialmente son 0
     


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        //Poner el contador a 0
        //Devolver el pajaro al inicio 
        GameObject Birdaux =GameObject.Find("pajaro");//Encuentra el Gameobject que se llame "pajaro"
        Birdaux.transform.position = new Vector3(-0.6f, -0.1f, 0f);//Cambia la posicion del pajaro a esta 
        Score.GetComponent<TextMeshProUGUI>().text = puntos.ToString();//Pone los puntos en el texto 
        if (puntos>maxScore)//Si se ha superado la puntuacion maxima
        {
            maxScore = puntos;//Se sutituye la puntuacion
            SaveMaxScore();//Se guarda la puntuacion en el metodo SaveMaxScore
            SmaxCore.GetComponent<TextMeshProUGUI>().text = maxScore.ToString();//Se guarda la puntuacion en el texto 
        }
        //Despues de la comprobacion puntos =0 
        //Se invoca el sonido en concreto y se cambia al estado de Game Over 
        puntos = 0;
        onSoundChoque?.Invoke(2 );
        UpdateContador();

        estadoactual = Estado.GameOver;
        onUpdateGameState?.Invoke(estadoactual);


    }
//Metodo de incremento de puntos 
//Se suma los puntos mas 1 
//Se actualiza el contador 
    public void IncreasePoints()
    
    {
        puntos++;
        
        
        UpdateContador();
        
    }
    //Metodo actualizar el contador 
    //Este metodo hace que los
    public void UpdateContador()
    {
       
        Contador.GetComponent<TextMeshProUGUI>().text = puntos.ToString();
        
    }
//Metodos para los distintos cambios de estado 
    public void StartGame( )
    {
        estadoactual = Estado.Game;
        onUpdateGameState?.Invoke(estadoactual);
        
    }

    public void ScoreBoard()
    {
        estadoactual = Estado.ScoreBoard;
        onUpdateGameState?.Invoke(estadoactual);
    }

    public void PauseGame()
    {
        estadoactual = Estado.Pause;
        onSounMenu?.Invoke(3 );
        onUpdateGameState?.Invoke(estadoactual);
    
    }

    public void Menu()
    {
      
        puntos = 0;
        UpdateContador();
        estadoactual = Estado.Start;
        onUpdateGameState?.Invoke(estadoactual);
        

    }
//Metodo para guardar la puntuacion maxima del jugador 
    public void SaveMaxScore()
    {
        PlayerPrefs.SetInt("MaxScore",maxScore);
    }
//Metodoo para coger  la puntuacion maximaque ha hecho el jugador 
    public int GetMaxScore()
    {
        maxScore = PlayerPrefs.GetInt("MaxScore");
        return maxScore;
    }
}

