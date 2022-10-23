using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PajaroHorizontal : MonoBehaviour
{
    Rigidbody2D rbPajaro;
    SpriteRenderer srPajaro;

    float velPajaro = 5;
    bool dir = true;//true izquierda, false derecha
    Rata rata;
    Vector3 posInicial;
    void Start()
    {
        rbPajaro = GetComponent<Rigidbody2D>();
        srPajaro = GetComponent<SpriteRenderer>();
        rata = GameObject.Find("Rata").GetComponent<Rata>();
        rbPajaro.velocity = new Vector2(velPajaro, 0);
      
        posInicial = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("ParedPajaro"))
        {
            if (dir)
            {
                dir = false;
                rbPajaro.velocity = new Vector2(-velPajaro, 0);
                srPajaro.flipX = false;
            }
            else
            {
                dir = true;
                rbPajaro.velocity = new Vector2(velPajaro, 0);
                srPajaro.flipX = true;
            }
        }

        if (other.gameObject.CompareTag("Rata"))
        {
            chocarRata();
        }

    }

    private void chocarRata()
    {
        rata.perderVida();
        transform.position = posInicial;
        rbPajaro.velocity = new Vector2(velPajaro, 0);
        dir = true;
    }
}
