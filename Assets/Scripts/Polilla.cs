using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polilla : MonoBehaviour
{
    Rata rata;
    Vector3 posInicial;
    void Start()
    {
        
        rata= GameObject.Find("Rata").GetComponent<Rata>();
        posInicial = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Rata"))
        {
            chocarRata();
        }

    }

    private void chocarRata()
    {
        rata.perderVida();
        transform.position = posInicial;
        
    }
}
