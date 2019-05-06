using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    private Material _myMaterial;
    void Start()
    {
        _myMaterial = GetComponent<Renderer>().material;
        StartCoroutine(MoveConveyor());
    }

    private IEnumerator MoveConveyor()
    {
        while (this.isActiveAndEnabled)
        {
            float newY = _myMaterial.mainTextureOffset.y;
            newY -= (Time.deltaTime * .1f);
            _myMaterial.mainTextureOffset = new Vector2(0, newY);
            yield return null;
        }
    }
}
