using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CodilityTests : MonoBehaviour
{
    private void Start()
    {

        //BinaryGap(75);
        //ShiftArray(new int[] { 5, 6, 7, 8 }, 2);
        //OddIntOut(new int[] { 8, 8, 94, 4, 90, 4, 94, 4, 90 });
        ////First Shift: [8,5,6,7]
        ////2nd Shift: [7,8,5,6]
        //FrogJmp(3, 999111321, 7);
        //PermutationFinder(new int[] { 4,1,3 });
        //FrogRiver(5, new int[] { 1, 3, 1, 4, 2, 3, 5, 4 });
        ////FrogRiver(2, new int[] { 1, 1, 1, 1, 1, 1, 1, 1 });
        //SmallestPositiveInt(new int[] { -1, -3, 1, 3 });
        //BinaryCounter(3, 7);
        //PairCounter(new int[]{ 3, 5, 6, 3, 3, 5});
        //PairCounter(BigIntArray(90000));
        //CheckersJumps(new string[] { "..X...", "......", "....X.", ".X....", "..X.X.", "...O.." });
    }

    public int CheckersJumps(string[] B)
    {
        //First things first, find Jafar's pawn
        KeyValuePair<int, int> jafarPawn = new KeyValuePair<int, int>();
        KeyValuePair<int, int> leftPawnTemp = new KeyValuePair<int, int>();
        KeyValuePair<int, int> rightPawnTemp = new KeyValuePair<int, int>();
        List<int> returnJumps = new List<int>();
        //Our board has to be atleast 3x3 to perform a jump
        if (B[0].Length < 3)
            return 0;
        for (int i = 0; i < B.Length; i++)
        {
            if (B[i].Contains('O'))
            {
                //This is the line with our Pawn. Need to determine where it is in the string
                jafarPawn = new KeyValuePair<int, int>(i, B[i].IndexOf('O'));
            }
        }
        //If the pawn is in one of the first two rows of the board, it can't jump anything
        if (jafarPawn.Key == 1 || jafarPawn.Key == 0)
            return 0;
        //Check for upper left jumps
        if (jafarPawn.Value > 1)
        {
            if (B[jafarPawn.Key - 1][jafarPawn.Value - 1] == 'X' && B[jafarPawn.Key - 2][jafarPawn.Value - 2] == '.')
            {
                //We have a jump. Now we need to check if upper right OR left OR both provide any more jumps
                int tempJumpCnt = 1;
                leftPawnTemp = new KeyValuePair<int, int>(jafarPawn.Key - 2, jafarPawn.Value - 2);
                //LEFT
                while (B[leftPawnTemp.Key - 1] != null && B[leftPawnTemp.Key - 2] != null)
                {
                    while (B[leftPawnTemp.Key - 1][leftPawnTemp.Value - 1] == 'X' && B[leftPawnTemp.Key - 2][leftPawnTemp.Value - 2] == '.')
                    {
                        tempJumpCnt++;
                        leftPawnTemp = new KeyValuePair<int, int>(leftPawnTemp.Key - 2, leftPawnTemp.Value - 2);
                    }
                    if (B[leftPawnTemp.Key - 1][leftPawnTemp.Value + 1] == 'X' && B[leftPawnTemp.Key - 2][leftPawnTemp.Value + 2] == '.')
                    {
                        //THIS MEANS THERE ARE JUMPS TO THE RIGHT. NEED TO COUNT THEM UP TOO
                        tempJumpCnt++;
                        leftPawnTemp = new KeyValuePair<int, int>(leftPawnTemp.Key - 2, leftPawnTemp.Value + 2);
                        while (B[leftPawnTemp.Key - 1][leftPawnTemp.Value + 1] == 'X' && B[leftPawnTemp.Key - 2][leftPawnTemp.Value + 2] == '.')
                        {
                            tempJumpCnt++;
                            leftPawnTemp = new KeyValuePair<int, int>(leftPawnTemp.Key - 2, leftPawnTemp.Value + 2);
                        }
                    }
                }
                returnJumps.Add(tempJumpCnt);
            }
        }
        //Check for upper right jumps
        if (jafarPawn.Value < B[0].Length - 2)
        {
            if (B[jafarPawn.Key - 1][jafarPawn.Value + 1] == 'X' && B[jafarPawn.Key - 2][jafarPawn.Value + 2] == '.')
            {
                //We have a jump. Now we need to check if upper right OR left OR both provide any more jumps
                int tempJumpCnt = 1;
                rightPawnTemp = new KeyValuePair<int, int>(jafarPawn.Key - 2, jafarPawn.Value + 2);
                //LEFT
                while (B[rightPawnTemp.Key - 1] != null && B[rightPawnTemp.Key - 2] != null)
                {
                    while (B[rightPawnTemp.Key - 1][rightPawnTemp.Value + 1] == 'X' && B[rightPawnTemp.Key - 2][rightPawnTemp.Value + 2] == '.')
                    {
                        tempJumpCnt++;
                        rightPawnTemp = new KeyValuePair<int, int>(leftPawnTemp.Key - 2, leftPawnTemp.Value + 2);
                    }
                    if (B[rightPawnTemp.Key - 1][rightPawnTemp.Value - 1] == 'X' && B[rightPawnTemp.Key - 2][rightPawnTemp.Value - 2] == '.')
                    {
                        //THIS MEANS THERE ARE JUMPS TO THE LEFT. NEED TO COUNT THEM UP TOO
                        tempJumpCnt++;
                        rightPawnTemp = new KeyValuePair<int, int>(rightPawnTemp.Key - 2, rightPawnTemp.Value - 2);
                        while (B[rightPawnTemp.Key - 1][rightPawnTemp.Value - 1] == 'X' && B[rightPawnTemp.Key - 2][rightPawnTemp.Value - 2] == '.')
                        {
                            tempJumpCnt++;
                            rightPawnTemp = new KeyValuePair<int, int>(rightPawnTemp.Key - 2, rightPawnTemp.Value - 2);
                        }
                    }
                }
                returnJumps.Add(tempJumpCnt);
            }
        }
        if (returnJumps.Any())
        {
            return returnJumps.Max();
        }
        return 0;
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
        for (int a = 0; a < returnArray.Length; a++)
        {
            returnArray[a] = myRandom.Next(-100000, 100000);
        }
        return returnArray;
    }
    public int PairCounter(int[] A)
    {
        int pairCount = 0;
        for (int i = 0; i < A.Length; i++)
        {
            for (int k = i + 1; k < A.Length; k++)
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
        for (int i = 0; i < A.Length; i++)
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
        for (int i = 0; i < A.Length; i++)
        {
            if (countDict.Keys.Contains(A[i]))
            {
                countDict[A[i]]++;
            }
            else
                countDict.Add(A[i], 1);
        }
        foreach (KeyValuePair<int, int> count in countDict)
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
        for (int i = 0; i < myList.Count; i++)
        {
            if (myList[i] != i + 1)
                return 0;
        }
        return 1;
    }

    public int FrogRiver(int X, int[] A)
    {
        List<int> myList = new List<int>();
        int[] myArray = new int[X + 1];
        for (int i = 0; i < A.Length; i++)
        {
            //if (!myList.Contains(A[i]))
            //{
            //    myList.Add(A[i]);
            //    if (myList.Count == X)
            //        return i;
            //}
            myArray[A[i]] = 1;
            return i;
        }

        return -1;
    }
    public int SmallestPositiveInt(int[] A)
    {
        int numToReturn = 1;
        List<int> myList = A.OrderBy(x => x).ToList();
        for (int i = 0; i < myList.Count; i++)
        {
            if (myList[i] == numToReturn)
            {
                numToReturn += 1;
            }
        }
        return numToReturn;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
