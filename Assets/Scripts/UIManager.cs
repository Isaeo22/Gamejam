using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject []interfaces;
    // Start is called before the first frame update
    private void Awake()
    {
        GameManager.onUpdateGameState += ChangeUI;
    }

    void Start()
    //En el Start hace que todoas las interfaces no se muestren escepto  la de Stargmae 
    {
        foreach (var interfaz in interfaces)
        {
            interfaz.SetActive(false);
        }

        interfaces[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
//Metodo para cambiar en la distintas interfaces 
    private void ChangeUI(GameManager.Estado e)
    {
        foreach (var interfaz in interfaces)
        {
            interfaz.SetActive(false);
        }
        switch (e)
        {//1 caso Start
            case GameManager.Estado.Start:
                interfaces[0].SetActive(true);
                break;
            
            case GameManager.Estado.Game:
                
                interfaces[1].SetActive(true);
                break;
          
            //Caso pausa 
            case GameManager.Estado.Pause:
                interfaces[2].SetActive(true);
                break;
            case GameManager.Estado.GameOver:
                interfaces[3].SetActive(true);
                break;
            default: break;
            
        }
    }
}
