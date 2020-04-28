using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PicSlice : MonoBehaviour
{
    public RectTransform myTransform;

    private int clickCnt;
    void Start()
    {
        myTransform = GetComponent<RectTransform>();
    }


    void Update()
    {
        
    }


    public void SliceClicked()
    {
        clickCnt += 1;
        if (clickCnt > 3)
            clickCnt = 0;
        //C'est la vie. Need to replace or add to clickCnt with a 'PicState' enum. Then we can have a 'SetState' method that the PicManager(coming soon) can use to randomly set the pic
        // pieces to different rotations
        switch (clickCnt)
        {
            case 1:
                myTransform.rotation = Quaternion.Euler(0, 0, 90);
                break;
            case 2:
                myTransform.rotation = Quaternion.Euler(0, 0, 180);
                break;
            case 3:
                myTransform.rotation = Quaternion.Euler(0, 0, 270);
                break;
            case 0:
                myTransform.rotation = Quaternion.Euler(0, 0, 0);
                break;
        }
        Debug.Log(name + " Click Cnt: " + clickCnt.ToString());
    }
}
