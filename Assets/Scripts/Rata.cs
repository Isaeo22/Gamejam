using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rata : MonoBehaviour
{
    [Range(1, 10)] public float velocidadRata;
    Rigidbody2D rbRata;
    SpriteRenderer srRata;
    Animator animRata;
    //CircleCollider2D cR;
    public bool isJumping = false;
    public float velSalto;
    Vector3 posInicial;
    float movimientoHorizontal = 0;

    bool isAlive = true;

    private void Start()
    {
        rbRata = GetComponent<Rigidbody2D>();
        srRata = GetComponent<SpriteRenderer>();
        animRata = GetComponent <Animator>();
        posInicial = transform.position;
       
    }

    private void FixedUpdate()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal");
        rbRata.velocity = new Vector2(movimientoHorizontal*velocidadRata,rbRata.velocity.y);

       if (movimientoHorizontal > 0)
        {
            srRata.flipX = true;
        }else if (movimientoHorizontal < 0)
        {
            srRata.flipX = false;
        }

        if (Input.GetButton("Jump") && !isJumping)
        {
           
            isJumping = true;
            animRata.SetBool("RatJumping", true);
            rbRata.velocity = new Vector2(rbRata.velocity.x,0f);
            rbRata.AddForce(new Vector2(0,velSalto), ForceMode2D.Impulse);
           
        }

    }

    private void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            animRata.SetBool("RatWalking", true);
        }
        else
        {
            animRata.SetBool("RatWalking", false);
        }
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
            animRata.SetBool("RatJumping", false);

        }

        if (other.gameObject.tag == "ParedPajaro")
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

    }

    public void perderVida()
    {
        isAlive = false;
        
    }
}
