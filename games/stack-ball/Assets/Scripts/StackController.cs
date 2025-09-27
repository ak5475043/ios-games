using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackController : MonoBehaviour
{
    [SerializeField]
    StackPartController[] stackPartControlls = null;
    [SerializeField]
    public Ball ball;

    private void Start()
    {
        ball = FindObjectOfType<Ball>();    
    }
    public void ShatterAllParts()
    {
        if(transform.parent != null)
        {
            transform.parent = null;
            ball.IncreaseBrokenStacks();
        }
        foreach(StackPartController o in stackPartControlls)
        {
            o.Shatter();
        }
        StartCoroutine(RemoveParts());
    }
    IEnumerator RemoveParts()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
