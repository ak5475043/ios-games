using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text scoreText;
    private void Start()
    {
        scoreText = GetComponent<Text>();
        if(PlayerPrefs.HasKey("CurrentScore"))
        scoreText.text = PlayerPrefs.GetInt("CurrentScore").ToString();
    }

    private void OnEnable()
    {
        MyEvents.AddScore += UpdateScore;
    }
    private void OnDisable()
    {
        MyEvents.AddScore -= UpdateScore;
    }
    void UpdateScore(int score)
    {
      scoreText.text = score.ToString();
    }
}
