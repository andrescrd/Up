using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  DG.Tweening;
using Scriptables;
using Random = UnityEngine.Random;

public class Platform : MonoBehaviour
{
    [SerializeField] private GameObject[] spikesPrefab;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private int chanceSpawn = 30;
    [SerializeField] private TextureScriptableObject texturesScriptableObject;
    
    private bool fallDawn;
    
    void Start()
    {
        ActivatePlatform();
        var render = GetComponent<Renderer>();
        render.material.mainTexture = texturesScriptableObject.GetTexture();
    }

    private void ActivateSpikes()
    {
        var index = Random.Range(0, spikesPrefab.Length);
        spikesPrefab[index].SetActive(true);
        spikesPrefab[index].transform.DOLocalMoveY(0.7f, 1.3f).SetLoops(-1, LoopType.Yoyo)
            .SetDelay(Random.Range(3.0f, 5.0f));
    }

    private void AddCoin()
    {
        var coin = Instantiate(coinPrefab);
        coin.transform.position = transform.position;
        coin.transform.DOLocalMoveY(0.4f, 0f);
        coin.transform.SetParent(transform);
    }

    private void ActivatePlatform()
    {
        var chance = Random.Range(0, 100);

        if (chance > chanceSpawn)
        {
            int type = Random.Range(0, 8);

            switch (type)
            {
                case 0:
                    ActivateSpikes();
                    break;  
                case 1:
                    AddCoin();
                    break;
                case 2:
                    fallDawn = true;
                    break;
                case 3:
                    break;
                case 4:
                    AddCoin();
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    AddCoin();
                    break;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (fallDawn)
            {
                fallDawn = false;  
                Invoke(nameof(InvokeFalling), 0.5f);
            }
        }
    }

    private void InvokeFalling()
    {
        gameObject.AddComponent<Rigidbody>();
        Destroy(gameObject,2.0f);
    }
}
