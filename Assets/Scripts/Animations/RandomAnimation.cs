using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var animator =  GetComponent<Animator>();
        animator.speed = Random.Range(0.5f, 1.5f);

    }
}
