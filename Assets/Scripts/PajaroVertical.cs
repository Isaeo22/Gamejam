using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PajaroVertical : MonoBehaviour
{
    Rigidbody2D rbPajaro;
    SpriteRenderer srPajaro;
    Vector3 posInicial;
    float velPajaro = 5;
    bool dir = true;//true izquierda, false derecha
    Rata rata;
    void Start()
    {
        rbPajaro = GetComponent<Rigidbody2D>();
        srPajaro = GetComponent<SpriteRenderer>();
        rata = GameObject.Find("Rata").GetComponent<Rata>();
        rbPajaro.velocity = new Vector2(0, velPajaro);
        posInicial = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("ParedPajaro"))
        {
            if (dir)
            {
                dir = false;
                rbPajaro.velocity = new Vector2(0, -velPajaro);
            }
            else
            {
                dir = true;
                rbPajaro.velocity = new Vector2(0, velPajaro);
                srPajaro.flipX = !srPajaro.flipX;
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
        rbPajaro.velocity = new Vector2(0, velPajaro);
        dir = true;
    }
}
