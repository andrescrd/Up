using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementForce = 0.5f;
    [SerializeField] private float jumpForce = 0.5f;
    [SerializeField] private float jumpTime = 0.15f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Jump(true);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Jump(false);
        }
    }

    private void Jump(bool left)
    {
        SoundManager.Instance.Jump();
        
        if (left)
        {
            transform.DORotate(new Vector3(0f, -90f, 0f), 0f);
            _rigidbody.DOJump(new Vector3(transform.position.x - movementForce,
                transform.position.y + jumpForce, transform.position.z), jumpForce, 1, jumpTime);
        }
        else
        {
            transform.DORotate(new Vector3(0f, 0, 0f), 0f);
            _rigidbody.DOJump(new Vector3(transform.position.x,
                transform.position.y + jumpForce, transform.position.z + movementForce), jumpForce, 1, jumpTime);
        }
    }
}