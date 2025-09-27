using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomepageUI : MonoBehaviour
{
    public Button playButton;
    GameObject playerInfoScreen;
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;

        playButton.onClick.AddListener(() => 
        {
            if(PlayerPrefs.GetString("playerName") == null)
            {
                playerInfoScreen.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene("GamePlay");
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
