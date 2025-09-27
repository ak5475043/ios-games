using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class APITest : MonoBehaviour
{
    public ToDO toDo;
    // Start is called before the first frame update
    void Start()
    {
        GetTodoList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetTodoList()
    {
        StartCoroutine(GetMyList());
        IEnumerator GetMyList()
        {
            UnityWebRequest uwr = UnityWebRequest.Get("https://dummyjson.com/todos?limit=20");
            yield return uwr.SendWebRequest();
            if(uwr.result == UnityWebRequest.Result.Success)
            {
                byte[] array = uwr.downloadHandler.data;
                string response = Encoding.Default.GetString(array);
                Debug.Log("Response = " + response);
                ToDoResponse toDoResponse = JsonUtility.FromJson<ToDoResponse>(response);
                toDo.SetUpToDoList(toDoResponse);
            }
            else
            {
                Debug.Log("No Response");
            }
        }
    }
}
