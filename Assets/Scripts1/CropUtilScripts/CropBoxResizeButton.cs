using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CropBoxResizeButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private bool _pressed;
    [SerializeField] private RectTransform _cropBoxRect;
    [SerializeField] public Transform WidthReferencePoint; //Set in Inspector to corresponding ResizeButton for Width
    [SerializeField] public Transform HeightReferencePoint; //Set in Inspector to corresponding ResizeButton for Height

    // Use this for initialization
    void Start ()
    {
        _cropBoxRect = transform.parent.GetComponent<RectTransform>();
		
	}
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        _pressed = true;
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        GetComponent<Image>().enabled = true;

        _pressed = false;
    }
    void Update ()
    {
        if (!_pressed)
        {
            GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            GetComponent<Image>().enabled = true;

            return;
        }
        Resize();
	}

    private void Resize()
    {
        transform.position = Input.mousePosition;
        GetComponent<Image>().enabled = false;
        GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        float myWidth = WidthReferencePoint.position.x - transform.position.x;
        float myHeight = HeightReferencePoint.position.y - transform.position.y;
        if (myWidth <0)
        {
            myWidth = myWidth * -1;
        }
        if (myHeight < 0)
        {
            myHeight = myHeight * -1;
        }

        _cropBoxRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, myWidth);
        _cropBoxRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, myHeight);

    }
}
