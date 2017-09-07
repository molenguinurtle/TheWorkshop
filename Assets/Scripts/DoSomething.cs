using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DoSomething : MonoBehaviour
{

    public int floatVar = 0;
    // Alright. Let's make this script change the color of the object it's attached to based off it's distance from
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Glass")
        {
            var myRbody = transform.GetComponent<Rigidbody>();
            myRbody.AddForce(Vector3.forward * -10, ForceMode.Force);
        }
    }
}
