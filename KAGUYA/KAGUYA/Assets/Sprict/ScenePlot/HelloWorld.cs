using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class HelloWorld : SceneBase
{
    public override void Interference(Status status)
    {
        // 生成
        status = new Status();

        StatusManager.instance.SetStatus(status);
        StatusManager.instance.SetDummyStatus(status);

        StatusSliderManager.instance.ChangeStatusUI();




    }

    public override void Start()
    {
        base.Start();

        Debug.Log("スタート");

        StatusManager.instance.StatusInterference(Interference);

    }

    public override void Update()
    {
        base.Update();

        End();
    }
    public override void End()
    {
        base.End();



        SceneManager.instance.SetScene(null);

        Debug.Log("終了");

    }




}
