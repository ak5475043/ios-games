using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDO : MonoBehaviour
{
    public ToDoList toDoListPrefab;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUpToDoList(ToDoResponse toDoResponse)
    {
        for(int i=0; i<toDoResponse.todos.Count; i++)
        {
            GameObject myListElement = Instantiate(toDoListPrefab.gameObject, transform);
            myListElement.GetComponent<ToDoList>().id.text = toDoResponse.todos[i].id.ToString();
            myListElement.GetComponent<ToDoList>().completed.text = toDoResponse.todos[i].completed.ToString();
            myListElement.GetComponent<ToDoList>().todo.text = toDoResponse.todos[i].todo.ToString();
            myListElement.GetComponent<ToDoList>().userId.text = toDoResponse.todos[i].userId.ToString();
        }
    }
}
