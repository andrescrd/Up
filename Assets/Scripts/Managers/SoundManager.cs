using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;

    public SoundManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = this;

            return _instance;
        }
    }

    [SerializeField] private AudioSource start, end, coin, jump;

    public void GameStart() => start.Play();
    public void GameEnd() => end.Play();
    public void Coin() => coin.Play();
    public void Jump() => jump.Play();
}