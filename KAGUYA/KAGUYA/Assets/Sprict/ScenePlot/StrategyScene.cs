using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrategyScene : SceneBase
{

    public override void Start()
    {
        base.Start();

        Debug.Log("作戦会議シーンを開始");

    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.E))
        {
            End();
        }

    }
    public override void End()
    {
        base.End();


        SceneManager.instance.SetScene(null);

        Debug.Log("終了");

    }


}
