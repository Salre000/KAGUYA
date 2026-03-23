using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// シーンのベース
public class SceneBase
{
    public virtual void Start() 
    {

    }

    public virtual void Update() { }

    public virtual void End() 
    {
        PlotManager.instance.AddPlotCount();

        CatinManager.instance.StartNormalCutin(() => 
        {
            PlotManager.instance.StartPlotScene();
        });

    }
    public virtual void Interference(Status status) { }

    protected readonly int HPDecrease = 8;
    protected readonly int AddStatus = 20;
}