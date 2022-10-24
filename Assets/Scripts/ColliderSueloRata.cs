using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSueloRata : MonoBehaviour
{


    public GameObject padre;
    private Animator animRata;

   
    // Start is called before the first frame update
    void Start()
    {
 
        animRata = padre.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Suelo"))
        {
            padre.GetComponent<Rata>().isJumping = false;
            animRata.SetBool("RatJumping", false);

        }

        if (other.gameObject.tag == "ParedPajaro")
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

    }
}
