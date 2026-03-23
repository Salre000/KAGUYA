using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunScene : SceneBase
{

    public override void Interference(Status status)
    {
        status.HP -= HPDecrease;

        status.fun += AddStatus + (int)(AddStatus * ((status.funRate + 100) / 100f));

        StatusManager.instance.SetStatus(status);


    }

    public override void Start()
    {
        base.Start();

        Debug.Log("ファンシーンを開始");

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
