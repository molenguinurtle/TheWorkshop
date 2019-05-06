using System.Collections;
using UnityEngine;

public class RotationManager : MonoBehaviour
{
#region Vars
    [SerializeField] private float _rotationInterval = -2f; //Interval we rotate the object at
    [SerializeField] private bool _areRotating; //Determines whether or not we're currently rotating the object
    public RectTransform RotateObject; //Object we're rotating
    public static RotationManager Instance; //Our Instance of RotationManager
    #endregion

#region Methods
    private void Awake ()
    {
        if (!Instance)
            Instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
	}

    /// <summary>
    /// Coroutine for rotating the assigned RotateObject
    /// </summary>
    /// <param name="rotationSpeed">Modifies the rate of rotation</param>
    /// <returns></returns>
    private IEnumerator RotateTheObject(float rotationSpeed)
    {
        if (RotateObject)
        {
            while (_areRotating)
            {
                RotateObject.Rotate(Vector3.forward, _rotationInterval * rotationSpeed);
                yield return null;
            }
        }
        else
        {
            Debug.LogError("RotateObject is not set! Have you set it in the Inspector?", RotateObject);
        }
    }

    /// <summary>
    /// Resets the rotation direction to clockwise, stops rotating the object, and zeros out its rotation
    /// </summary>
    public void Reset()
    {
        _areRotating = false;
        StopAllCoroutines();
        if (_rotationInterval > 0)
            FlipRotation();
        RotateObject.rotation = new Quaternion(0, 0, 0, 0);
    }

    /// <summary>
    /// Flips the direction the RotateObject rotates in between clock and counter-clockwise
    /// </summary>
    public void FlipRotation()
    {
        _rotationInterval = _rotationInterval * -1f;
    }

    /// <summary>
    /// Toggles on/off the rotation of RotateObject
    /// </summary>
    public void ToggleRotate()
    {
        _areRotating = !_areRotating;
        if (_areRotating)
            StartCoroutine(RotateTheObject(1f));
        else
            StopCoroutine(RotateTheObject(1f));
    }
#endregion

}
