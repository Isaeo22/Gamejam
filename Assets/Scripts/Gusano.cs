using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gusano : MonoBehaviour
{
    SpriteRenderer srGusi;
    Animator animGus;
    // Start is called before the first frame update
    void Start()
    {
        animGus = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {


        if (other.gameObject.tag == "Rata")
        {
            animGus.SetBool("RataCerca", true);
            
        }

    }

   
}
