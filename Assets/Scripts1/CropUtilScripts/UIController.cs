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
    public Image[] currentImages;
    private List<Sprite> tempSpriteLst;

    public int LANDSCAPE_WIDTH_CONST;
    public int LANDSCAPE_HEIGHT_CONST;
    public int PORTRAIT_WIDTH_CONST;
    public int PORTRAIT_HEIGHT_CONST;

    private void Start()
    {
        tempSpriteLst = new List<Sprite>();
    }
    public void CutImagePressed()
    {
        if (mySprite != null)
            GenerateSprites();
    }

    public void AssignSpritesPressed()
    {
        if (currentSprites.Length > 11)
        {
            AssignSprites();
        }
    }
    private void GenerateSprites()
    {
        //First, get our Picture
        Texture2D texToCut = mySprite.sprite.texture;
        int width = 0;
        int height = 0;
        //Set w/h vars based on Landscape/Portrait. Can add in SQUARE Constants later
        if (texToCut.width > texToCut.height)
        {
            //Use Landscape Constants
            width = LANDSCAPE_WIDTH_CONST;
            height = LANDSCAPE_HEIGHT_CONST;
        }
        else
        {
            //Use Portrait Constants
            width = PORTRAIT_WIDTH_CONST;
            height = PORTRAIT_HEIGHT_CONST;
        }
        //Reset the tempSpriteLst
        tempSpriteLst = new List<Sprite>();

        //Cut the picture up into width x height sized sprites
        for (int sawY = 0; sawY < texToCut.height;sawY+= height)
        {
            for (int sawX =0; sawX < texToCut.width; sawX += width)
            {
                Color[] pix = texToCut.GetPixels(sawX, sawY, width, height);
                Texture2D cutTex = new Texture2D(width, height);
                cutTex.SetPixels(pix);
                cutTex.Apply();
                tempSpriteLst.Add(Sprite.Create(cutTex,
                                new Rect(0, 0,
                                          cutTex.width,
                                          cutTex.height),
                                                new Vector2(0, 0), 100.0f));
            }
        }

        //Set the currentSprites to those Sprites
        currentSprites = tempSpriteLst.ToArray();


    }

    //C'est la vie. We're cutting up the Pictures into sprites. Now we just need a collection of Buttons/Images(prolly just Images) that are set up to swap out Sprites painlessly
    // AKA, AssignSprites will basically be a for loop where we loop thru currentSprites and assign to an Image[x]'s sprite component. See commented out code below
    private void AssignSprites()
    {
        for (int x = 0; x < currentSprites.Length; x++)
        {
            currentImages[x].sprite = currentSprites[x];
            currentImages[x].SetNativeSize();
        }
        // Set the object's texture to show the extracted rectangle.
        //mySprite.sprite = Sprite.Create(destTex,
        //                        new Rect(0, 0,
        //                                  destTex.width,
        //                                  destTex.height),
        //                                        new Vector2(0, 0), 100.0f);
        //mySprite.SetNativeSize();
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
