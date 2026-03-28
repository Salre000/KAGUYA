using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SceneCanvasManager;

public class KassenScene : SceneBase
{

    public override void Interference(Status status)
    {
        // 生成
    }

    public override void Start()
    {
        base.Start();

        Debug.Log("合戦スタート");

        CatinManager.instance.StartNormalCutin(() =>
        {

            SceneCanvasManager.instance.StartSceneCanvas((int)plotSceneEnum.Kassen);
        });



    }

    public override void Update()
    {
        base.Update();

    }
    public override void End()
    {
        PlotManager.instance.AddPlotCount();

        CatinManager.instance.StartNormalCutin(() =>
        {
            PlotManager.instance.StartPlotScene();
            SceneCanvasManager.instance.SceneEnd();

        });
    }





}
