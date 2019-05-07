using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Events;
using System.IO;

public class ImageController : MonoBehaviour
{

    [SerializeField] string _imageURL;

    [SerializeField] public Texture2D TheImage;

    [SerializeField] private Texture2D _cropTex;

    [SerializeField] public Image ImageHolderMaterial;

    [SerializeField] public Image CropHolderMaterial;

    [SerializeField] private Sprite _theSprite;

    [SerializeField] public GameObject CropBox;

    [SerializeField] private UnityEvent ImageDownloaded;

    [SerializeField] private UnityEvent UndoNeeded;

    [SerializeField] private int _saveCount;

    [SerializeField] public static ImageController Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    IEnumerator GetImage(string imageURL)
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(imageURL))
        {
            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                TheImage = DownloadHandlerTexture.GetContent(uwr);
            }
        }
        if (TheImage != null)
        {
            SetImage(TheImage, ImageHolderMaterial);
            ImageDownloaded.Invoke();
        }
    }


    public void TryGetImage(string url)
    {
        _imageURL = url;
        StartCoroutine(GetImage(_imageURL));
    }

    private void SetImage(Texture2D theImage, Image imageHolder, bool cropped = false)
    {
        if (cropped || theImage.width < 800 || theImage.height < 600)
        {
            _theSprite = Sprite.Create(theImage, new Rect(0.0f, 0.0f, theImage.width, theImage.height), new Vector2(0.5f, 0.5f), 100.0f);
            imageHolder.color = new Color(255,255,255,255);
        }
        else
        {
            _theSprite = Sprite.Create(theImage, new Rect(0.0f, 0.0f, 800f, 600f), new Vector2(0.5f, 0.5f), 100.0f);
        }
        imageHolder.sprite = _theSprite;
        imageHolder.type = Image.Type.Simple;
    }

    public void EnableCropBox()
    {
        CropBox.SetActive(true);
    }
    public void DisableCropBox()
    {
        CropBox.SetActive(false);
    }

    public  void Save()
    {
        Debug.Log("Pressed SAVE. IMPLEMENT THE SAVE FUNCTION");
        Texture2D savedImage = _cropTex;
        byte[] bytes = savedImage.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/../croppedImg-" + _saveCount + ".png", bytes);
        _saveCount++;
        Undo(true);
    }

    public void Undo(bool savedReset)
    {
        CropHolderMaterial.enabled = false;
        CropHolderMaterial.color = new Color(1.0f, 1.0f, 1.0f, (float)100f/255f);
        CropHolderMaterial.sprite = null;
        CropBox.GetComponent<CropBox>().ToggleResizeControls(true);
        CropHolderMaterial.enabled = true;
        EnableCropBox();
        ImageHolderMaterial.enabled = true;
        if (savedReset)
        {
            UndoNeeded.Invoke();
        }
    }

    public void Crop()
    {
        //Rect _cropRect = GetScreenCoordinates(CropBox.GetComponent<RectTransform>());
        Rect _cropRect =CropBox.GetComponent<RectTransform>().rect;
        Vector2 _cropPos = CropBox.GetComponent<RectTransform>().anchoredPosition;

        //int x = Mathf.FloorToInt(_cropRect.x);
        //int y = Mathf.FloorToInt(_cropRect.y);

        int x = Mathf.FloorToInt(_cropPos.x- (_cropRect.width/2));
        int y = Mathf.FloorToInt(_cropPos.y - (_cropRect.height/2));

        int width = Mathf.FloorToInt(_cropRect.width);
        int height = Mathf.FloorToInt(_cropRect.height);

        //C'est la vie. These checks won't be necessary if you limit the range you can modify the crop square to the bounds of "TheImage"
        // THIS IS NEXT. WE DO THIS, WE FIX THE ISSUES IT HAS WITH SMALLER IMAGES WITH THE 'Texture rectangle is out of bounds (164 + 412 > 500)' ERROR
        //HOW DO WE FIX IT? SIMPLE: DO EXACTLY WHAT YOU SAID BEFORE- DON'T ALLOW THE SQUARE TO BE MODIFIED OUTSIDE THE IMAGE
        //   OR, IN HERE, We're gonna have to do a BIG conversion of the Rect's bounds using "TheImage"'s dimensions to determine width, height, and starting points (x, y)
        // WE. GOT. THIS.
        //  THEN WE JUST NEED TO PUT IN OUR CHECKS TO VERIFY THAT WE'RE GETTING AN IMAGE

        if (x <0)
        {
            x = 0;
        }
        if (y < 0)
        {
            y = 0;
        }
        if (height > 600)
        {
            height = 600;
        }
        if (width > 800)
        {
            width = 800;
        }
        Color[] pix = TheImage.GetPixels(x, y, width, height);

        _cropTex = new Texture2D(width, height);
        _cropTex.SetPixels(pix);
        _cropTex.Apply();

        SetImage(_cropTex, CropHolderMaterial, true);
        ImageHolderMaterial.enabled = false;
        CropBox.GetComponent<CropBox>().ToggleResizeControls(false);

    }


}
    


