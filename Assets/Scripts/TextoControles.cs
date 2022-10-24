using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextoControles : MonoBehaviour
{
    public GameObject pj;
    private Vector3 posObj;
    // Start is called before the first frame update
    void Start()
    {
        posObj = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posPj = pj.GetComponent<Transform>().position;

        Color color = this.GetComponent<SpriteRenderer>().color;

        


        color.a = calcDist(posPj);



        this.GetComponent<SpriteRenderer>().color = color;
    }

    public float calcDist(Vector3 pos)   //Devuelve un valor entre 0 y 1
    {
        float x = Mathf.Abs(posObj.x - pos.x);
        float y = Mathf.Abs(posObj.y - pos.y);
        float dist = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));

        float val = funCuad(dist);
        Debug.Log(val);
        return val;
    }

    public float funCuad(float val)
    {
        float y = 1 - (Mathf.Pow(val*0.5f, 4)) / 2;
        if (y < 0)
        {
            y = 0;
        }
        return y;
    }
}
