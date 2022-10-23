using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rana : MonoBehaviour
{
    Rigidbody2D rbRana;
    SpriteRenderer srRana;

    float velRana = 1f;
    bool dir = true;//true izquierda, false derecha
    Rata rata;
    Vector3 posInicial;
    void Start()
    {
        rbRana = GetComponent<Rigidbody2D>();
        srRana = GetComponent<SpriteRenderer>();
        
        rbRana.velocity = new Vector2(velRana, 0);

        posInicial = transform.position;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Suelo"))
        {
            if (dir)
            {
                dir = false;
                rbRana.velocity = new Vector2(-velRana, 0);
                srRana.flipX = true;
            }
            else
            {
                dir = true;
                rbRana.velocity = new Vector2(velRana, 0);
                srRana.flipX = false;
            }
        }

        if (other.gameObject.tag == "Rata")
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            
        }
    }

}
