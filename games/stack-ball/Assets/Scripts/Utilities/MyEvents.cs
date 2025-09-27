using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEvents : MonoBehaviour
{
    public static MyEvents instance;

    public static Action<int> AddScore;

    //public delegate void DelegateWithNoParameter();
    ////public static DelegateWithNoParameter OnGetGrid;




    //public static DelegateWithNoParameter GetRoom;
}
