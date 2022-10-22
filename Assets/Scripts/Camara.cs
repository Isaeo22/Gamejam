using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject personaje;
    private Vector3 posicionRelativa;
    public float yOffset;
    // Use this for initialization
    void Start()
    {

        posicionRelativa = transform.position - personaje.transform.position;
        posicionRelativa.y += yOffset;

    }

    // Update is called once per frame
    void LateUpdate()
    {

        transform.position = personaje.transform.position + posicionRelativa;

    }
}
