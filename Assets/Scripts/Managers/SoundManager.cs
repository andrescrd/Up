using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource start, end, coin, jump;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void GameStart() => start.Play();
    public void GameEnd() => end.Play();
    public void Coin() => coin.Play();
    public void Jump() => jump.Play();
}