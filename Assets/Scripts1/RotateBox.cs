using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBox : MonoBehaviour
{
    private float rotateYVar;
    private float rotateXVar;
    private float rotateTimer = 0;
	// Use this for initialization
	void Start ()
    {
        UpdateRotationVars(Random.Range(-1, 1), Random.Range(-1, 1));
    }

    // Update is called once per frame
    void Update ()
    {
        rotateTimer += Time.deltaTime;
        if (rotateTimer < 5)
        {
            //Start rotating the box using the rotateVar
            //Every 5 secs want to change rotation
            transform.Rotate(Vector3.up * (rotateYVar * 2*Time.deltaTime));
            transform.Rotate(Vector3.forward * (rotateXVar *2* Time.deltaTime));

        }
        else
        {
            UpdateRotationVars(Random.Range(-1, 1), Random.Range(-1, 1));
            rotateTimer = 0;
        }

    }

    private void UpdateRotationVars(int yModifier, int xModifier)
    {
        if (yModifier==0 && xModifier ==0)
        {
            yModifier = 1;
            xModifier = -1;
        }
        rotateYVar = Random.Range(2.5f*yModifier, 4.5f*yModifier);
        rotateXVar = Random.Range(2.5f * xModifier, 4.5f * xModifier);

    }
}
