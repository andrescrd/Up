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

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _uiManager = GameObject.FindObjectOfType<UIManager>();
    }

    public void AddScore()
    {
        _uiManager.IncrementScore();
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
}