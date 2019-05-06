using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigibodyStuff : PooledObject
{

    public Rigidbody Body { get; private set;}
	
	void Awake ()
    {
        Body = GetComponent<Rigidbody>();	
	}

    private void OnTriggerEnter(Collider collided)
    {
        if (collided.CompareTag("EndZone"))
        {
            ReturnToPool();
        }
    }
}
