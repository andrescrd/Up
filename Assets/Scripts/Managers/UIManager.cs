using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text ScoreText;
    private int _score = 0;

    public void IncrementScore()
    {
        _score++;
        ScoreText.text = $"x{_score}";
    }
}