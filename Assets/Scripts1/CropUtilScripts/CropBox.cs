using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CropBox : MonoBehaviour 
{
    [SerializeField] private Button[] myButtons;
    private void Start()
    {
        myButtons = transform.GetComponentsInChildren<Button>();
    }
    public void ToggleResizeControls(bool controlsOn)
    {
        foreach (var i in myButtons)
        {
            i.gameObject.SetActive(controlsOn);
        }
    }
}
