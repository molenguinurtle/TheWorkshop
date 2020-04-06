using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CropBox : MonoBehaviour 
{
    [SerializeField] private Button[] myButtons;
    public int PICTURE_COUNT;
    private int GROUP_COUNT; //This is the amount of pictures in each group. We will have 365(or 366 depending on year) equal groups unless the math gives 
                                // us an odd number. In that case, we'll just add the pics not already placed in the last X number of groups til we're all sorted
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
        var numList = new List<int>();
        List<string> groupList = new List<string>();
        for(int i =1;i < PICTURE_COUNT+1; i++)
        {
            numList.Add(i);
        }
        for (int g =0; g<365;g++) //For as many groups as we need; For each group
        {
            string newGroup = "";
            for (int p =0;p < GROUP_COUNT;p++ ) //Randomly assign a set of numbers ranging from 1-X(the Picture Count)
            {
                var rnd = Random.Range(0, numList.Count);
                newGroup += numList[rnd] + ".";
                numList.RemoveAt(rnd);
            }
            //Check for Odd number/Leftover in numList here. Or have it figured out from before when determining GROUP_COUNT
            groupList.Add(newGroup);

        }
    }
}
