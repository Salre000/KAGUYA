using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SceneCanvasManager;

public class OrderScene : SceneBase
{


    public override void Start()
    {
        base.Start();

        Debug.Log("通販シーンを開始");

        CatinManager.instance.StartNormalCutin(() =>
        {

            SceneCanvasManager.instance.StartSceneCanvas((int)plotSceneEnum.Order);
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



        SceneManager.instance.SetScene(null);

        Debug.Log("終了");
    }


}
