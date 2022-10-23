using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topo : MonoBehaviour
{
    Rigidbody2D rbTopo;
    SpriteRenderer srTopo;
    Animator animTopo;
    float velSalto;
    Vector3 posicionTopo = new Vector3(18.9029999f, -0.8f, 0);
    bool isJumping = false;
    Rata rata;
    Vector3 posInicial;
    public bool randomizarSalto=false;
    void Start()
    {
        rbTopo= GetComponent<Rigidbody2D>();
        srTopo=GetComponent<SpriteRenderer>();
        animTopo = GetComponent<Animator>();
        rata = GameObject.Find("Rata").GetComponent<Rata>();
        velSalto = 5;
        posInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= posicionTopo.y && rbTopo.velocity.y < 0)
        {
            animTopo.SetBool("jumping", false);
        }
        else
        {
            animTopo.SetBool("jumping", true);
        }

        if (!isJumping)
        {
            if (randomizarSalto)
            {
                velSalto = Random.Range(3, 10);
            }
            isJumping = true;

            rbTopo.velocity = new Vector2(rbTopo.velocity.x, 0f);
            rbTopo.AddForce(new Vector2(0, velSalto), ForceMode2D.Impulse);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        

        /*if (other.gameObject.CompareTag("HitboxHoyo"))
        {
            posicionTopo = transform.position;
            animTopo.SetBool("jumping", false);
            animTopo.SetBool("enAgujero", true);
            //Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        */

        if (other.gameObject.CompareTag("Suelo"))
        {
            isJumping = false;
            rbTopo.velocity = new Vector2(rbTopo.velocity.x, 0);
        }

        if (other.gameObject.tag == "ParedPajaro")
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
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
    }
}
