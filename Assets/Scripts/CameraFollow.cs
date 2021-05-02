using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float dumping = 2.0f;
    [SerializeField] private float height = 10.0f;
    private Transform _player;
    private Vector3 _starPos;
    private bool _canFollow;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;
        _starPos = _player.position;
        _canFollow = true;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    private void Follow()
    {
        if (_canFollow)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(_player.position.x + 10,
                _player.position.y + height, _player.position.z - 10), Time.deltaTime * dumping);
        }
    }
}
