using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    //[SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    private bool juegoPausado = false;
    private AudioSource musica;

    private void Awake()
    {
        musica = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausa();
            }
        }
    }
    public void Pausa()
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        //botonPausa.SetActive(false);
        menuPausa.SetActive(true);
        musica.Pause();
    }

    public void Reanudar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        //botonPausa.SetActive(true);
        menuPausa.SetActive(false);
        musica.Play();
    }

    public void Reiniciar()
    {
        juegoPausado = false;
        Time.timeScale =1f ;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void Cerrar()
    {
        Debug.Log("Cerrar juego ");
        Application.Quit();
    }
}
