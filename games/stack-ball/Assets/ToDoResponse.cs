using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ToDoResponse
{
    public List<Todo> todos;
    public int total;
    public int skip;
    public int limit;
}
   [Serializable]
public class Todo
{
    public int id;
    public string todo;
    public bool completed;
    public int userId;
}

