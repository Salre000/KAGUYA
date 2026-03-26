using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpriteObjects")]
public class SpriteScriptableObject : ScriptableObject
{
    [SerializeField] List<Sprite> sprites = new List<Sprite>();
}
