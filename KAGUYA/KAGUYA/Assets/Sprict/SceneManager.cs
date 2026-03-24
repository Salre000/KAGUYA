using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static SceneManager instance;

    private SceneBase nowScene;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nowScene == null) return;


        if (StatusManager.instance.CheckDummyStatus()) return;

        nowScene.Update();




    }

    public void SetScene(SceneBase sceneBase) {nowScene = sceneBase;}

    public void SceneEnd() { nowScene.End(); }


    public void AddPlotCount() {}


}
