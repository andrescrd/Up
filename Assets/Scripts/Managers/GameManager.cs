using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = System.Object;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    private UIManager _uiManager;
    private AdsManager _adsManager;

    private int _score = 0;
    private int _highScore = 0;
    private int _currentScore = 0;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        if (PlayerPrefs.HasKey("score"))
            _highScore =  PlayerPrefs.GetInt("score");    
        
        if (PlayerPrefs.HasKey("currentScore"))
            _currentScore =  PlayerPrefs.GetInt("currentScore");

        _score = _currentScore;
    }

    private void Start()
    {
        _uiManager = GameObject.FindObjectOfType<UIManager>();
        _adsManager = GameObject.FindObjectOfType<AdsManager>();
        _uiManager.SetHighScore(_highScore);
        _uiManager.SetScore(_currentScore);        
    }
   
    public void Quit()
    {
        Application.Quit();
    }

    public int GetHighScore() => _highScore;
    
    public void AddScore()
    {
        _score++;
        _uiManager.SetScore(_score);        

        if (_score > _highScore)
        {
            _highScore = _score;
            PlayerPrefs.SetInt("score",_highScore);            
            PlayerPrefs.SetInt("currentScore", _score);
        }
    }

    public void ReloadGame(bool clearData=true)
    {
        if (clearData)
        {
            _adsManager.ShowInterstitialAd();
            PlayerPrefs.DeleteKey("currentScore");
        }
        
        Invoke(nameof(Restart), 3f);
    }

    private void Restart()
    {
        Play();
    }
    
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene(0);        
    }
}