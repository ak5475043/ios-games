using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public Text scoreText;
    public int score = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetInt("Level", 1);
        }
        //MakeSingleton();
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("Highscore") == false)
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
        AddScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void MakeSingleton()
    //{
    //    if(instance != null)
    //        Destroy(gameObject);
    //    else
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //}

    public void AddScore(int amount)
    {
        score += amount;
        if(score> PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
        PlayerPrefs.SetInt("CurrentScore", score);
        MyEvents.AddScore?.Invoke(score);
        //scoreText.text = score.ToString();
    }
}
