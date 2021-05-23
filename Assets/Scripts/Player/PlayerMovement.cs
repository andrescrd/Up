using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementForce = 0.5f;
    [SerializeField] private float jumpForce = 0.5f;
    [SerializeField] private float jumpTime = 0.15f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody _rigidbody;
    private SphereCollider _groundCollider;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _groundCollider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Jump(true);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Jump(false);
        }
    }

    public void Jump(bool left)
    {
        if (!IsGrounded())
            return;
        
        SoundManager.Instance.Jump();

        if (left)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            _rigidbody.DOJump(new Vector3(transform.position.x - movementForce,
                transform.position.y + jumpForce, transform.position.z), jumpForce, 1, jumpTime);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _rigidbody.DOJump(new Vector3(transform.position.x,
                transform.position.y + jumpForce, transform.position.z + movementForce), jumpForce, 1, jumpTime);
        }
    }

    private bool IsGrounded()
    {
        return  Physics.CheckCapsule(_groundCollider.bounds.center,
            new Vector3(_groundCollider.bounds.center.x, _groundCollider.bounds.min.y, _groundCollider.bounds.center.z),
            _groundCollider.radius * .9f, groundLayer);
    }
}