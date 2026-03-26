using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCanvas : MonoBehaviour
{
    // そのプロットのイメージ画像
    [SerializeField] protected SpriteScriptableObject sceneImage;

    public virtual void SceneStart() { }

    public virtual void SceneEnd() { }


}
