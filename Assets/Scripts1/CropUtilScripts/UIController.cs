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


    private void Start()
    {

        BinaryGap(75);
        ShiftArray(new int[] { 5, 6, 7, 8 }, 2);
        OddIntOut(new int[] { 8, 8, 94, 4, 90, 4, 94, 4, 90 });
        //First Shift: [8,5,6,7]
        //2nd Shift: [7,8,5,6]
        FrogJmp(3, 999111321, 7);
        PermutationFinder(new int[] { 4,1,3 });
        FrogRiver(5, new int[] { 1, 3, 1, 4, 2, 3, 5, 4 });
        //FrogRiver(2, new int[] { 1, 1, 1, 1, 1, 1, 1, 1 });
        SmallestPositiveInt(new int[] { -1, -3, 1, 3 });
        BinaryCounter(3, 7);
        PairCounter(new int[]{ 3, 5, 6, 3, 3, 5});
        PairCounter(BigIntArray(90000));

    }
    public int BinaryCounter(int A, int B)
    {
        int oneCount = 0;
        long myNum = (long)A * (long)B;
        string binaryN = Convert.ToString(myNum, 2);
        foreach (char c in binaryN)
        {
            if (c == '1')
                oneCount++;
        }
        return oneCount;
    }
    public int BinaryGap(int N)
    {
        var binaryGapLst = new List<int>();
        if (N > 0)
        {
            string binaryN = Convert.ToString(N, 2);
            if (binaryN.Length >= 3)
            {
                //This means there is a possibility of a binary gap
                for (int i = 0; i < binaryN.Length; i++)
                {
                    if (binaryN[i] == '0')
                    {
                        continue;
                    }
                    else
                    {
                        if ((i + 1) < binaryN.Length && (i + 2) < binaryN.Length && binaryN[i + 1] == '0')
                        {
                            //Chance of binary gap
                            int a = i + 1;
                            char nextNum = binaryN[a];
                            int tempCount = 0;
                            while (nextNum == '0' && a < binaryN.Length)
                            {
                                tempCount++;
                                a++;
                                if (a < binaryN.Length)
                                {
                                    nextNum = binaryN[a];
                                }
                            }
                            if (nextNum == '1')
                            {
                                //We have a  binary gap
                                binaryGapLst.Add(tempCount);
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                if (binaryGapLst.Count > 0)
                {
                    //We have a list of binary gaps. Return the largest one
                    Debug.Log("Max binary gap of " + N + ": " + binaryGapLst.Max());
                    return binaryGapLst.Max();
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
        return 0;
    }

    public int[] BigIntArray(int arraySize)
    {
        int[] returnArray = new int[arraySize];
        System.Random myRandom = new System.Random();
        for (int a =0; a< returnArray.Length; a++)
        {
            returnArray[a] = myRandom.Next(-100000, 100000);
        }
        return returnArray;
    }
    public int PairCounter(int[] A)
    {
        int pairCount = 0;
        for (int i =0; i < A.Length; i++)
        {
            for (int k = i+1; k < A.Length;k++)
            {
                if (A[i] == A[k])
                    pairCount++;
            }
        }
        if (pairCount > 1000000000)
            pairCount = 1000000000;
        return pairCount;
    }

    public int TriangleFinder(int[] A)
    {
        List<int> perimLst = new List<int>();
        for (int i =0; i < A.Length; i++)
        {
            //Need to determine if 
        }
        return 1;
    }

    public int[] ShiftArray(int[] A, int K)
    {
        int shiftCnt = 0;
        if (A.Length > 1)
        {
            while (shiftCnt < K)
            {
                int firstNum = A[A.Length - 1];
                for (int i = A.Length - 1; i >= 0; i--)
                {
                    if (i > 0)
                    {
                        A[i] = A[i - 1];
                    }
                    else
                        A[i] = firstNum;
                }

                shiftCnt++;
            }
            return A;
        }
        return A;
    }
    public int OddIntOut(int[] A)
    {
        var countDict = new Dictionary<int, int>();
        for (int i =0; i < A.Length; i++)
        {
            if (countDict.Keys.Contains(A[i]))
            {
                countDict[A[i]]++;
            }
            else
                countDict.Add(A[i], 1);
        }
        foreach (KeyValuePair<int,int> count in countDict)
        {
            if ((count.Value % 2) > 0)
            {
                //This is our value. We need its key
                return count.Key;
            }
        }
        return 0;
    }
    public int FrogJmp(int X, int Y, int D)
    {
        if (X == Y)
        {
            return 0;
        }
        else
        {
            if ((Y - X) % D == 0)
            {
                return (int)(Y - X) / D;
            }
            return (int)((Y - X) / D) + 1;
        }
    }

    public int PermutationFinder(int[] A)
    {
        List<int> myList = A.OrderBy(x => x).ToList();
        for (int i =0; i< myList.Count;i++)
        {
            if (myList[i] != i+1)
                return 0;
        }
        return 1;
    }

    public int FrogRiver(int X, int[] A)
    {
        List<int> myList = new List<int>();
        int[] myArray = new int[X+1];
        for (int i = 0; i < A.Length; i++)
        {
            //if (!myList.Contains(A[i]))
            //{
            //    myList.Add(A[i]);
            //    if (myList.Count == X)
            //        return i;
            //}
            myArray[A[i]] =1;
                return i;
        }

        return -1;
    }
    public int SmallestPositiveInt(int[] A)
    {
        int numToReturn = 1;
        List<int> myList = A.OrderBy(x => x).ToList();
        for (int i =0; i < myList.Count; i++)
        {
            if (myList[i] == numToReturn)
            {
                numToReturn += 1;
            }
        }
        return numToReturn;
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
