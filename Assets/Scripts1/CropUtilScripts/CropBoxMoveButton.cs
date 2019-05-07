using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class CropBoxMoveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField] private bool _pressed;
    [SerializeField] private RectTransform _cropBoxRect;
    [SerializeField] private Vector2 _pictureBounds;
    [SerializeField] private float _xRightLim;
    void Start()
    {
        _cropBoxRect = transform.parent.GetComponent<RectTransform>();
        _pictureBounds = new Vector2(ImageController.Instance.ImageHolderMaterial.rectTransform.rect.width, ImageController.Instance.ImageHolderMaterial.rectTransform.rect.height);

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
    void Update()
    {
        if (!_pressed)
        {
            GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            GetComponent<Image>().enabled = true;

            return;
        }
        Move();
    }

    private void Move()
    {
        _cropBoxRect.position = Input.mousePosition;
        if ((_cropBoxRect.anchoredPosition.x + (_cropBoxRect.rect.width / 2))> _pictureBounds.x) //We're too far to the right
        {
            _xRightLim = _cropBoxRect.anchoredPosition.x;
            _cropBoxRect.position = new Vector3(_xRightLim, Input.mousePosition.y);
        }
    }
}
