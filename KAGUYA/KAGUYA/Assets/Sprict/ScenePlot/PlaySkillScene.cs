using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySkillScene : SceneBase
{

    public override void Interference(Status status)
    {

        StatusManager.instance.SetStatus(status);

    }

    public override void Start()
    {
        base.Start();

        Debug.Log("プレイスキルシーンを開始");

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

        StatusManager.instance.StatusInterference(Interference);

        SceneManager.instance.SetScene(null);

        Debug.Log("終了");

    }


}
