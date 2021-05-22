using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text ScoreText;
    [SerializeField] private Text HighScoreText;

    public void SetScore(int score = 0)
    {
        ScoreText.text = $"x{score}";
    }

    public void SetHighScore(int score = 0)
    {
        if (HighScoreText == null)
            return;
        
        HighScoreText.text = HighScoreText && score > 0 ? $"{score}" : string.Empty;
    }
}