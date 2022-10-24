using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arana : MonoBehaviour
{
    Rigidbody2D rbAraña;
    SpriteRenderer srAraña;

    float velAraña = 1f;
    bool dir = true;//true arriba, false abajo
    Rata rata;
    Vector3 posInicial;
    int randomGravity=1;
 
    int motionUnits=3;
    

    void Start()
    {
        rbAraña = GetComponent<Rigidbody2D>();
        srAraña = GetComponent<SpriteRenderer>();
        rata = GameObject.Find("Rata").GetComponent<Rata>();
        rbAraña.velocity = new Vector2(0, velAraña);
        posInicial = transform.position;
    }

    private void Update()
    {        
     
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("TechoAraña"))
        {
            randomGravity = Random.Range(1,5);
            rbAraña.gravityScale = randomGravity;
            
        }

        if (other.gameObject.CompareTag("Rata"))
        {
            chocarRata();
        }

        if (other.gameObject.CompareTag("Suelo"))
        {
            velAraña = Random.Range(1, 5);
            rbAraña.gravityScale = 0;
            rbAraña.velocity = new Vector2(0, velAraña);
        
        }

    }

    private void chocarRata()
    {
        rata.perderVida();
        transform.position = posInicial;
        rbAraña.velocity = new Vector2(0, velAraña);
        dir = true;
    }

}
