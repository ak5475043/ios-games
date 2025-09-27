using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Vector3 camFollow;
    public Transform ball, win;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(win == null)
        {
            win = GameObject.Find("Win(Clone)").GetComponent<Transform>();   
        }
        if(transform.position.y > ball.transform.position.y && transform.position.y > win.position.y + 4f)
        {
            camFollow = new Vector3(transform.position.x , ball.position.y, -5);
        }
        transform.position = new Vector3(transform.position.x , camFollow.y, -5);
    }
}
