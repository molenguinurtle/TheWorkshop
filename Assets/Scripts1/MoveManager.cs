using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour
{
    public Transform mySphere;

    public Transform[] movePoints; //Points we move mySphere to on the Plane
    private int _moveIndex = 0;
    void Start()
    {
        if (mySphere)
        {
            StartCoroutine(MoveSphere());
        }
    }

    private IEnumerator MoveSphere()
    {
        while (Vector3.Distance(mySphere.position, movePoints[_moveIndex].position) > .01f)
        {
            mySphere.position = Vector3.MoveTowards(mySphere.position, movePoints[_moveIndex].position, 2.3f * Time.deltaTime);
            if (Vector3.Distance(mySphere.position, movePoints[_moveIndex].position) < .01f)
            {
                _moveIndex++;
                if (_moveIndex >= movePoints.Length)
                    _moveIndex = 0;
            }
            yield return null;
        }
    }
}
