﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject startPlatformPrefab, endPlatformPrefab, platformPrefab;
    [SerializeField] private int amountSpawn = 100;
    [SerializeField] private float blockWidth = 0.5f;
    [SerializeField] private float blockHeight = 0.2f;

    private int _currentAmount = 0;
    private Vector3 _lastPos = new Vector3();
    private List<GameObject> _plattforms = new List<GameObject>();

    private void Awake()
    {
        InstantiateLevel();
    }

    private void InstantiateLevel()
    {
        for (int i = 0; i < amountSpawn; i++)
        {
            GameObject newPlatform;

            if (i == 0)
            {
                newPlatform = Instantiate(startPlatformPrefab);
            }
            else if (i == amountSpawn - 1)
            {
                newPlatform = Instantiate(endPlatformPrefab);
                newPlatform.tag = "EndPlatform";
            }
            else
            {
                newPlatform = Instantiate(platformPrefab);
            }

            newPlatform.transform.parent = this.transform;
            _plattforms.Add(newPlatform);

            if (i == 0)
            {
                _lastPos = newPlatform.transform.position;
                
                var tempPos = _lastPos;
                tempPos.y += 0.1f;
                Instantiate(playerPrefab, tempPos, Quaternion.identity);
                
                continue;
            }

            int left = Random.Range(0, 2);

            if (left == 0)
            {
                newPlatform.transform.position = new Vector3(
                    _lastPos.x - blockWidth, _lastPos.y + blockHeight, _lastPos.z);
            }
            else
            {
                newPlatform.transform.position = new Vector3(
                    _lastPos.x, _lastPos.y + blockHeight, _lastPos.z + blockWidth);
            }

            _lastPos = newPlatform.transform.position;

            if (i < 25)
            {
                var endPos = newPlatform.transform.position.y;
                newPlatform.transform.position = new Vector3(newPlatform.transform.position.x,
                    newPlatform.transform.position.y - blockHeight * 3f, newPlatform.transform.position.z);

                newPlatform.transform.DOLocalMoveY(endPos, 0.3f).SetDelay(i * 0.1f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}