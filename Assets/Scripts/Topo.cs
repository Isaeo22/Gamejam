using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topo : MonoBehaviour
{
    Rigidbody2D rbTopo;
    SpriteRenderer srTopo;
    float velSalto;
    bool isJumping = false;
    Rata rata;
    void Start()
    {
        rbTopo= GetComponent<Rigidbody2D>();
        srTopo=GetComponent<SpriteRenderer>();
        rata = GameObject.Find("Rata").GetComponent<Rata>();
        velSalto = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isJumping)
        {
            //velSalto = Random.Range(1,10);
            isJumping = true;
            rbTopo.velocity = new Vector2(rbTopo.velocity.x, 0f);
            rbTopo.AddForce(new Vector2(0, velSalto), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

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
    }
}
