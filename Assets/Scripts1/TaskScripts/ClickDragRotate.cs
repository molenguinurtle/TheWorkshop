using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDragRotate : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 8f;

    private void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * _rotateSpeed;
        float rotY = Input.GetAxis("Mouse Y") * _rotateSpeed;
        transform.Rotate(Vector3.up, -rotX, Space.World);
        transform.Rotate(Vector3.right, rotY,Space.World);

    }

}
