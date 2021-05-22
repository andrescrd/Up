using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scriptables
{
    [CreateAssetMenu(fileName = "Textures", menuName = "Up", order = 0)]
    public class TextureScriptableObject : ScriptableObject
    {
        [SerializeField] private Texture2D[] textures;
        [SerializeField] private Sprite[] backgrounds;

        public Texture2D GetTexture()
        {
            var index = Random.Range(0, textures.Length);
            return textures[index];
        }
                
        public Sprite GetBackground()
        {
            var index = Random.Range(0, backgrounds.Length);
            return backgrounds[index];
        }
    }
}