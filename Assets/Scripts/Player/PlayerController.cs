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

    // Start is called before the first frame update
    public void Jump(bool left)
    {
        _playerInteraction.Jump(left);
    }
}
