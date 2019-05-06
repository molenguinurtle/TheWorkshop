using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[RequireComponent(typeof(Material))]
public class DoSomething : MonoBehaviour
{

    public int floatVar = 0;
    private Material myMaterial;
    void Awake()
    {
        myMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Cube"))
        {
            var myColor = myMaterial.color;
            myColor.r += 1;
            myMaterial.color = myColor;
        }
        if (collision.transform.CompareTag("Sphere"))
        {
            var myColor = myMaterial.color;
            myColor.b += 1;
            myMaterial.color = myColor;
        }
    }
}
