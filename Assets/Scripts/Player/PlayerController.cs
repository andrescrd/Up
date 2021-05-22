using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement _playerInteraction;

    private void Start()
    {
        _playerInteraction = GameObject.FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        ExitGame();
    }

    // Start is called before the first frame update
    public void Jump(bool left)
    {
        _playerInteraction.Jump(left);
    }

    public void ExitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            GameManager.Instance.OpenMenu();
    }    
}
