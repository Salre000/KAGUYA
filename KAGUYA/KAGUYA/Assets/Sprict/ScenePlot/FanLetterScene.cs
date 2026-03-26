using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SceneCanvasManager;

public class FanLetterScene : SceneBase
{
    public override void Start()
    {
        base.Start();

        CatinManager.instance.StartNormalCutin(() =>
        {

            SceneCanvasManager.instance.StartSceneCanvas((int)plotSceneEnum.FunLetter);
        });

    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.E))
        {
            End();
        }

    }
    /// <summary>
    ///  この関数は基底クラスの物を使わない
    /// </summary>
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
