using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arana : MonoBehaviour
{
    Rigidbody2D rbAra�a;
    SpriteRenderer srAra�a;

    float velAra�a = 1f;
    bool dir = true;//true arriba, false abajo
    Rata rata;
    Vector3 posInicial;
    int randomGravity=1;
 
    int motionUnits=3;
    

    void Start()
    {
        rbAra�a = GetComponent<Rigidbody2D>();
        srAra�a = GetComponent<SpriteRenderer>();
        rata = GameObject.Find("Rata").GetComponent<Rata>();
        rbAra�a.velocity = new Vector2(0, velAra�a);
        posInicial = transform.position;
    }

    private void Update()
    {        
     
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("TechoAra�a"))
        {
            randomGravity = Random.Range(1,5);
            rbAra�a.gravityScale = randomGravity;
            
        }

        if (other.gameObject.CompareTag("Rata"))
        {
            chocarRata();
        }

        if (other.gameObject.CompareTag("Suelo"))
        {
            velAra�a = Random.Range(1, 5);
            rbAra�a.gravityScale = 0;
            rbAra�a.velocity = new Vector2(0, velAra�a);
        
        }

    }

    private void chocarRata()
    {
        rata.perderVida();
        transform.position = posInicial;
        rbAra�a.velocity = new Vector2(0, velAra�a);
        dir = true;
    }

}
