using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private bool _died;

    private CameraFollow _cameraFollow;

    private void Awake()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _cameraFollow = Camera.main.GetComponent<CameraFollow>();
    }

    private void Update()
    {
        if (!_died && _rigidbody.velocity.sqrMagnitude > 60)
        {
            _died = true;
            _cameraFollow.CanFollow(false);
            SoundManager.Instance.GameEnd();
            GameManager.Instance.ReloadGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            SoundManager.Instance.Coin();
            GameManager.Instance.AddScore();
        } else if (other.transform.CompareTag("Spike"))
        {
            _cameraFollow.CanFollow(false);
            gameObject.SetActive(false);
            SoundManager.Instance.GameEnd();
            GameManager.Instance.ReloadGame();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("EndPlatform"))
        {
            SoundManager.Instance.GameStart();
            GameManager.Instance.ReloadGame(false);
        }
    }
}
