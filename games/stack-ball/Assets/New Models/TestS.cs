using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestS : MonoBehaviour
{
    int rnum = 1243;
    int reversedNumber;
    string tempreversedNumber;
    int[] array = { 4, 6, 2, 8, 9, 10, 5, 7 };
    int maxNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        int num = MaxNumber();
        ReverseNumber();
        Debug.Log(tempreversedNumber);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public int MaxNumber()
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > maxNumber)
            {
                maxNumber = array[i];
            }
        }
        return maxNumber;
    }

    public void ReverseNumber()
    {
       for(int i = 1000; i>=10; i = i / 10)
        {
            reversedNumber += (int)(rnum / i);
            tempreversedNumber += (int)(rnum / i);
            rnum = rnum - (i*reversedNumber);
        }
        
    }
}
