using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class UIController : MonoBehaviour {

    [SerializeField] private GameObject GetImagePanel;
    [SerializeField] private GameObject CropPanel;
    [SerializeField] private GameObject CropOptionsPanel;
    [SerializeField] private GameObject EnableCroppingButton;

    [SerializeField] private InputField TheInputField;

    public Image mySprite;
    public Sprite[] currentSprites;
    private List<Sprite> tempSpriteLst;

    private void Start()
    {
        tempSpriteLst = new List<Sprite>();
    }
    public void CutImagePressed()
    {
        if (mySprite != null)
            GenerateSprites();
    }

    private void GenerateSprites()
    {
        Texture2D texToCut = mySprite.sprite.texture;
        //int x = Mathf.FloorToInt(sourceRect.x);
        //int y = Mathf.FloorToInt(sourceRect.y);
        int x = Mathf.FloorToInt(0); //These (x,y of the 'rect' for cuttin up Pictures) will change as part of a for loop (hopefully not too complicated) or 3
        //Something like below. 'Mathf.FloorToInt(texToCut.width/4f)' will actually just be the 'widthConstant' discussed below. The same will go for 'y' and the 'heightConstant' 
        //for (x =0; x < texToCut.width; x += Mathf.FloorToInt(texToCut.width/4f))
        int y = Mathf.FloorToInt(0);
        int width = Mathf.FloorToInt(1024);//This will need to be a figured out constant #; Will change depending on if an image is Landscape or Portrait style; Once a resolution
                                            // is decided upon for the photos and the "play area"(read: place where user clicks image pieces to rotate them), this will be set. Might change
                                            //depending on System specs, operating system, etc. (FUUUUUUUUUUU)
        //int height = Mathf.FloorToInt(768);//Same as above
        int height = Mathf.FloorToInt(1536);
        Color[] pix = texToCut.GetPixels(x, y, width, height);
        Texture2D destTex = new Texture2D(width, height);
        destTex.SetPixels(pix);
        destTex.Apply();

        // Set the object's texture to show the extracted rectangle.
        mySprite.sprite = Sprite.Create(destTex,
                                new Rect(0, 0,
                                          destTex.width,
                                          destTex.height),
                                                new Vector2(0, 0), 100.0f);
        mySprite.SetNativeSize();
        //C'est la vie. OK OK OK. We got it! See notes above. Basically, GetPixels is referencing the actual texture/PICTURE in the Assets folder. So, the 'rect' that we make to cut up
        // the Photos must reference their dimensions, NOT the dimensions of 'mySprite.' AKA, whatever you have your IMAGE_HOLDER's Width and Height set to DOES. NOT. MATTER. for GetPixels.
    }

    public void EnableCropButtonPressed()
    {
        //C'est la vie. Need a couple things here. First, we have to turn off the UI for entering the URL for the image. Then we'll need to turn on 
        //  the UI for saving out the image once cropped.
        ImageController.Instance.EnableCropBox();
        EnableCroppingButton.SetActive(false);
        GetImagePanel.SetActive(false);
        CropPanel.SetActive(true);
    }

    public void DisableCropButtonPressed()
    {
        ImageController.Instance.DisableCropBox();
        CropPanel.SetActive(false);
        GetImagePanel.SetActive(true);
        EnableCroppingButton.SetActive(true);
    }

    public void CropButtonPressed()
    {
        ImageController.Instance.Crop();
        CropPanel.SetActive(false);
        CropOptionsPanel.SetActive(true);
    }

    public void UndoButtonPressed()
    {
        ImageController.Instance.Undo(false);
        ReturnToCropScreen();
    }

    public void ReturnToCropScreen()
    {
        CropOptionsPanel.SetActive(false);
        CropPanel.SetActive(true);
    }

    public void SaveButtonPressed()
    {
        ImageController.Instance.Save();
    }

    public void GetImagePressed()
    {
        //C'est la vie. Need to do a check here to make sure the address entered in field is valid (isn't empty and ends in 'png' or 'jpg' or 'jpeg' ). If valid, tell
        // ImageController.Instance to try GetImage
        //if (TheInputField.text)
        ImageController.Instance.TryGetImage(TheInputField.text);

    }


}
