using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameUI : MonoBehaviour
{
    public static GameUI instance;
    public GameObject homeUI, inGameUI,gameOverUI;
    public GameObject allButtons;
    private bool buttons;
    private bool flag = true;

    [Header("PreGamme")]
    public Button soundButton;
    public Sprite soundOn, soundOff;
    public Button tapToPlayBtn;

    [Header("In Game")]
    public Image levelSlider;
    public Image currentLevelImg;
    public Image nextLevelImg;
    public Text currentLevelText;
    public Text nextLevelText;

    [Header("GameOver")]
    public Button replayBtn;

    public Material ballMaterial;
    public Ball ball;

    private void Awake()
    {
        Debug.Log("ballmaterial color = " + ballMaterial.color);
        levelSlider.transform.parent.GetComponent<Image>().color = ballMaterial.color + Color.gray;
        levelSlider.color = ballMaterial.color;
        currentLevelImg.color = ballMaterial.color;
        nextLevelImg.color = ballMaterial.color;
        currentLevelText.text = PlayerPrefs.GetInt("Level").ToString();
        nextLevelText.text = (PlayerPrefs.GetInt("Level") + 1).ToString();
        Debug.Log("currentLevelText " + currentLevelText.text);
    }
    private void Start()
    {
        tapToPlayBtn.onClick.AddListener(() => 
       {
           Debug.Log("Tap to Play is pressed");
           ball.ballState = Ball.BallState.Playing;
           homeUI.SetActive(false);
           inGameUI.SetActive(true);

       });
        replayBtn.onClick.AddListener(() => 
       {
           PlayerPrefs.SetInt("Level", 1);
           PlayerPrefs.SetInt("CurrentScore", 0);
           SceneManager.LoadScene(0);
           //ball.ballState = Ball.BallState.Playing;
           //homeUI.SetActive(false);
           //inGameUI.SetActive(true);
           //gameOverUI.SetActive(false);
           

       });

        soundButton.onClick.AddListener(() => 
        {
            SoundManager.instance.SoundOnOff();
            if (SoundManager.instance.sound)
                soundButton.gameObject.GetComponent<Image>().sprite = soundOn;            
            else
                soundButton.gameObject.GetComponent<Image>().sprite = soundOff;

            //flag = !flag;
        });
    }
    // Update is called once per frame
    void Update()
    {
        
        //if (Input.GetMouseButtonDown(0) && !IgnoreUI() && ball.ballState == Ball.BallState.Prepare)
        //{
        //    ball.ballState = Ball.BallState.Playing;
        //    homeUI.SetActive(false);
        //    inGameUI.SetActive(true);
        //}

    }

    private bool IgnoreUI()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResultList = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResultList);
        for (int i = 0; i < raycastResultList.Count; i++)
        {
            if (raycastResultList[i].gameObject.GetComponent<Ignore>() != null) 
            {
                raycastResultList.RemoveAt(i);
                i--;
            }
        }
        return raycastResultList.Count > 0;
    }
    public void LevelSliderFill(float fillAmount)
    {
        levelSlider.fillAmount = fillAmount;
    }

    public void Settings()
    {
        buttons = !buttons;
        allButtons.SetActive(buttons);
    }
}
