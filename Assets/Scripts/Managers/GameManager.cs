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
    private int _score = 0;
    private int _highScore = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        if (PlayerPrefs.HasKey("score"))
            _highScore =  PlayerPrefs.GetInt("score");        
    }

    private void Start()
    {
        _uiManager = GameObject.FindObjectOfType<UIManager>();
        _uiManager.SetHighScore(_highScore);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
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
        }
    }

    public void ReloadGame()
    {
        Invoke(nameof(Restart), 3f);
    }

    private void Restart()
    {
        var sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene(0);        
    }
}