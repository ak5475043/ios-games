using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToDoList : MonoBehaviour
{
    public Text id;
    public Text todo;
    public Text completed;
    public Text userId;

    private void Awake()
    {
        id = transform.Find("Id").GetComponent<Text>(); 
        todo = transform.Find("Todo").GetComponent<Text>(); 
        completed = transform.Find("Completed").GetComponent<Text>(); 
        userId = transform.Find("UserId").GetComponent<Text>(); 
        
    }
   
}
