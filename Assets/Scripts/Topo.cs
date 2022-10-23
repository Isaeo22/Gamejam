using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topo : MonoBehaviour
{
    Rigidbody2D rbTopo;
    SpriteRenderer srTopo;
    Animator animTopo;
    float velSalto;
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
        if (!isJumping)
        {
            if (randomizarSalto)
            {
                velSalto = Random.Range(3, 10);
            }
            isJumping = true;
            animTopo.SetBool("jumping", true);

            rbTopo.velocity = new Vector2(rbTopo.velocity.x, 0f);
            rbTopo.AddForce(new Vector2(0, velSalto), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        animTopo.SetBool("jumping", false);

        if (other.gameObject.CompareTag("Suelo"))
        {
            isJumping = false;
            rbTopo.velocity = new Vector2(rbTopo.velocity.x, 0);
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
