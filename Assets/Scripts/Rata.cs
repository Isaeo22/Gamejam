using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rata : MonoBehaviour
{
    [Range(1, 10)] public float velocidadRata;
    Rigidbody2D rbRata;
    SpriteRenderer srRata;
    bool isJumping = false;
    public float velSalto;
    Vector3 posInicial;

    bool isAlive = true;

    private void Start()
    {
        rbRata = GetComponent<Rigidbody2D>();
        srRata = GetComponent<SpriteRenderer>();
        posInicial = transform.position;
    }

    private void FixedUpdate()
    {
        float movimientoHorizontal = Input.GetAxisRaw("Horizontal");
        rbRata.velocity = new Vector2(movimientoHorizontal*velocidadRata,rbRata.velocity.y);

       if (movimientoHorizontal > 0)
        {
            srRata.flipX = false;
        }else if (movimientoHorizontal < 0)
        {
            srRata.flipX = true;
        }

        if (Input.GetButton("Jump") && !isJumping)
        {
           
            isJumping = true;
            rbRata.velocity = new Vector2(rbRata.velocity.x,0f);
            rbRata.AddForce(new Vector2(0,velSalto), ForceMode2D.Impulse);
           
        }

    }

    private void Update()
    {
        if (!isAlive)
        {
            isAlive = true;
            transform.position = posInicial;
            Debug.Log("Has muerto ;3");
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
       
        if (other.gameObject.CompareTag("Suelo"))
        {
            isJumping = false;
            rbRata.velocity = new Vector2(rbRata.velocity.x, 0);
        }
    }

    public void perderVida()
    {
        isAlive = false;
        
    }
}
