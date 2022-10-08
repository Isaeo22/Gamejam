using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update


    
    public  enum Estado{Start,Game,Pause,GameOver};//Los distintos estados que tiene el juego 
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
        
    }

    void Start()
    {
        
      
     


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
   

        estadoactual = Estado.GameOver;
        onUpdateGameState?.Invoke(estadoactual);


    }

    //Metodo actualizar el contador 
    //Este metodo hace que los
   
//Metodos para los distintos cambios de estado 
    public void StartGame( )
    {
        estadoactual = Estado.Game;
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
      
      
        estadoactual = Estado.Start;
        onUpdateGameState?.Invoke(estadoactual);
        

    }


}

