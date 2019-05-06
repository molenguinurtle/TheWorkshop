using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class FlipRotationButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float downYPos; //The position of the mouse in Y coords when the click is started
    [SerializeField] private bool _isFlipped; //Determines if the switch is currently flipped (read: usable) or not

#region Methods
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!_isFlipped)
            downYPos = Input.mousePosition.y;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (Input.mousePosition.y > downYPos && !_isFlipped)
        {
            //Make call to RotationManager to Flip Rotation
            RotationManager.Instance.FlipRotation();
            // Make call to GameManager to increase FlipRotationButton's Click Count
            GameManager.Instance.UpdateFlipCount();
            //Start Courotine to flip, and then unflip Switch
            StartCoroutine(FlipSwitch(1.5f));
            // Don't allow switch flipping while coroutine is running
        }
    }

    /// <summary>
    /// Inverts and disables the switch graphic for a defined amount of time before returning it to normal
    /// </summary>
    /// <param name="duration">How long the switch should stay flipped/inactive before it's usable again</param>
    /// <returns></returns>
    private IEnumerator FlipSwitch(float duration)
    {
        transform.localScale = new Vector3(transform.localScale.x, -1*transform.localScale.y, 1);
        _isFlipped = true;
        downYPos = 0;
        yield return new WaitForSeconds(duration);
        transform.localScale = new Vector3(transform.localScale.x, -1 * transform.localScale.y, 1);
        _isFlipped = false;

    }
#endregion

}
