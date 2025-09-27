using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    Rigidbody myRigidbody;
    float currentTime;
    bool smash, invincible;

    public LevelSpawner levelSpawner;
    public GameUI gameUI;
    public GameObject invicibleObj;
    public Image invincibleFill;
    public GameObject fireEffect;

    int currentBrokenStacks;
    int totalStacks;
    public enum BallState
    {
        Prepare,
        Playing,
        Died,
        Finish
    }

    [HideInInspector]
    public BallState ballState= BallState.Prepare;

    public AudioClip bounceOffClip;
    public AudioClip deadClip;
    public AudioClip winClip;
    public AudioClip destroyClip;
    public AudioClip iDestroyClip;
    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
        currentBrokenStacks = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        totalStacks = FindObjectsOfType<StackController>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Ball State = " + ballState);
        if (ballState == BallState.Playing)
        {
            if (Input.GetMouseButtonDown(0))
            {
                smash = true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                smash = false;
            }
            if (invincible)
            {
                currentTime -= Time.deltaTime * 0.35f;
                if (!fireEffect.activeInHierarchy)
                    fireEffect.SetActive(true);
            }
            else
            {
                if (fireEffect.activeInHierarchy)
                    fireEffect.SetActive(false);
                if (smash)
                {
                    currentTime += Time.deltaTime * 0.8f;
                }
                else
                {
                    currentTime -= Time.deltaTime * 0.5f;
                }
            }
            if (currentTime >= 0.3f || invincibleFill.color == Color.red)
                invicibleObj.SetActive(true);
            else invicibleObj.SetActive(false);
            if (currentTime >= 1)
            {
                currentTime = 1;
                invincible = true;
                invincibleFill.color = Color.red;
            }
            else if (currentTime <= 0)
            {
                currentTime = 0;
                invincible = false;
                invincibleFill.color = Color.white;
            }

            if (invicibleObj.activeInHierarchy)
                invincibleFill.fillAmount = currentTime / 1;
        }
        //if(ballState == BallState.Prepare)
        //{
        //    if(Input.GetMouseButtonDown(0))
        //    {
        //        ballState = BallState.Playing;
        //    }
        //}
        if(ballState == BallState.Finish) 
        {
            if(Input.GetMouseButtonDown (0))
            {
                levelSpawner.NextLevel();
            } 
        }
    }
    private void FixedUpdate()
    {
        if (ballState == BallState.Playing)
        {
            if (Input.GetMouseButton(0))
            {
                smash = true;
                myRigidbody.velocity = new Vector3(0, -100 * Time.fixedDeltaTime * 7, 0);
            }
        }
        //if (myRigidbody.velocity.y >5)
        //{
        //    myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, 5, myRigidbody.velocity.z);
        //}
    }

    public void IncreaseBrokenStacks()
    {
        //Debug.Log("Called");
        currentBrokenStacks++;
        if (!invincible)
        {
            ScoreManager.Instance.AddScore(1);
            SoundManager.instance.PlaySound(destroyClip, 0.5f);
        }
        else
        {
            ScoreManager.Instance.AddScore(2);
            SoundManager.instance.PlaySound(iDestroyClip, 0.5f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!smash)
        {
            myRigidbody.velocity = new Vector3(0,50*Time.deltaTime*5, 0);
            SoundManager.instance.PlaySound(bounceOffClip, 0.5f);
        }
        else
        {
            if (invincible)
            {
                if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "plane")
                {
                    collision.transform.parent.GetComponent<StackController>().ShatterAllParts();
                }
            }
            else
            {
                if (collision.gameObject.tag == "enemy")
                {
                    collision.transform.parent.GetComponent<StackController>().ShatterAllParts();
                }
                if (collision.gameObject.tag == "plane")
                {
                    ballState = BallState.Died;
                    Debug.Log("Over");
                    gameUI.gameOverUI.SetActive(true);
                    //ScoreManager.instance.ResetScore();
                    SoundManager.instance.PlaySound(deadClip, 0.5f);
                }
            }
        }
        gameUI.LevelSliderFill(currentBrokenStacks/(float)totalStacks);
        if(collision.gameObject.tag == "Finish"&& ballState == BallState.Playing) 
        { 
            ballState = BallState.Finish;
            SoundManager.instance.PlaySound(winClip, 0.7f);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (!smash || collision.gameObject.tag == "Finish") 
        {
            myRigidbody.velocity = new Vector3(0, 50 * Time.deltaTime * 5, 0);
        }
    }
}
