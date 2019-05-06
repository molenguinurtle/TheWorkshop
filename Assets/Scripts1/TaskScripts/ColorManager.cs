using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public Renderer whiteSphere;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Clickable"))
                {
                    //We clicked one of the color-changing spheres. Change the whiteSphere to that sphere's material
                    whiteSphere.material = hit.transform.GetComponent<Renderer>().material;
                }
            }
        }
    }
}
