using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform target;
    public float zoomSpeed;
    public float zoomOutBarrier;
    public float zoomInBarrier;

    // Use this for initialization
    void Start ()
    {
		if (target ==null)
        {
            target = GameObject.FindGameObjectWithTag("Target").transform;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        Zoom();
	}

    private void LateUpdate()
    {
        transform.LookAt(target);
    }

    private void Zoom()
    {
        float stepSpeed = zoomSpeed * Time.deltaTime;

        if (Input.GetAxis("ScrollWheel") > 0f)
        {
            if (Vector3.Distance(transform.position, target.position) > zoomInBarrier)
            {
                //Zoom in/ move the camera closer /or scale the object up
                transform.position = Vector3.MoveTowards(transform.position, target.position, stepSpeed);
            }
        }
        else if (Input.GetAxis("ScrollWheel") < 0f)
        {
            if (Vector3.Distance(transform.position, target.position) < zoomOutBarrier)
            {
                //Zoom out/ move the camera away from the target/ or scale the object down
                transform.position = Vector3.MoveTowards(transform.position, target.position, stepSpeed * -1f);
            }

        }
    }
}
