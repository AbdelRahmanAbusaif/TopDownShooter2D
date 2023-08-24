using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   
    public TextMeshProUGUI TimeScore;
    public TextMeshProUGUI hiScoreText;
    public TextMeshProUGUI AmmoCount;
    public float ScoreTime;
    
    void Start()
    {
        ScoreTime = 0f;
        hiScoreText.text = PlayerPrefs.GetFloat("HighScore", 0f).ToString("0.0");
    }

    void Update()
    {
        ScoreTime += Time.deltaTime;
        TimeScore.text = ScoreTime.ToString("0.0");
        if(Input.GetKey(KeyCode.P))
            ResetHiscore();
        AmmoCount.text=PlayerMovement.CurrentBullet.ToString("0");
    }

    public void MenuScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        ScoreKill.ScoreValue=0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void restart()
    {
        SceneManager.LoadScene("game");
        Time.timeScale = 1;
    }

    public void gameOver()
    {   
        UpdateHiscore();

        SceneManager.LoadScene("GameOver");
        Time.timeScale = 0;
    }

    public void UpdateHiscore()
    {  
        if (ScoreTime > PlayerPrefs.GetFloat("HighScore", 0f)) 
        {
            PlayerPrefs.SetFloat("HighScore", ScoreTime);
            hiScoreText.text = ScoreTime.ToString("0.0");
        }
        if (ScoreTime > PlayerPrefs.GetFloat("HighScore", 0f)) 
            {
                Debug.Log("New high score achieved!");
                PlayerPrefs.SetFloat("HighScore", ScoreTime);
                hiScoreText.text = ScoreTime.ToString("0.0");
            }
    }

    public void ResetHiscore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        hiScoreText.text = "0.0";
    }
}
