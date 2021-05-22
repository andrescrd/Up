using System.Collections;
using System.Collections.Generic;
using Scriptables;
using UnityEngine;
using UnityEngine.UI;

public class CameraBackground : MonoBehaviour
{
    [SerializeField] private Image imageBackground;
    [SerializeField] private TextureScriptableObject textureScriptableObject;

    // Start is called before the first frame update
    void Start()
    {
        imageBackground.sprite = textureScriptableObject.GetBackground();
    } 
}
