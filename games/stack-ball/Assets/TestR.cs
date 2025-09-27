using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestR : MonoBehaviour
{
    int[] a = { 3, 7, 1, 5, 4, 5 };
    int num;
    // Start is called before the first frame update
    void Start()
    {
        num = PrintSecond();
        Debug.Log(num);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int PrintSecond()
    {
        int temp=0;
        int temp2 = 0;
        for(int i=0; i<a.Length; i++)
        {
            if (a[i] > temp2 && temp2 < temp)
            {
                Debug.Log("*");
                temp2 = a[i];
            }
            if (a[i] > temp)
            {
                temp = a[i];
            }
           
            
        }
        return temp2;
    }
        
}
