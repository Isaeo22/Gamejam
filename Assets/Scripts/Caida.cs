using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caida : MonoBehaviour
{


    Rata rata;
    Vector3 posInicial;
    // Start is called before the first frame update
    void Start()
    {
        rata = GameObject.Find("Rata").GetComponent<Rata>();
        posInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
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
