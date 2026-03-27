using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlotManager : MonoBehaviour
{

    public static PlotManager instance;

    //　現在のプロット
    private int plotCount = 0;

    //プロットの最大値
    private readonly int MAX_PLOT = 17;

    // プロットの中身
    private List<List<int>> plotDecided=new List<List<int>>();

    // プロットのデータの参照先
    private readonly string FILE_NAME = "Plot";

    [SerializeField] TextMeshProUGUI TestText;

    public void Awake()
    {
        instance= this;
        StartPlotDecided();

    }
    public void Start()
    {
        SetPlotScene();
    }


    public void SetPlotScene(int ID = -1)
    {

        SceneBase scene = null;
        switch (ID)
        {
            case -1:
                scene = new HelloWorld();
                break;

            case 0:
                scene = new FriendScene();
                break;

            case 1:
                scene = new PlaySkillScene();
                break;

            case 2:
                scene = new FunScene();
                break;
            case 3:
                scene = new OrderScene();
                break;

            case 4:
                scene = new StrategyScene();
                break;

            case 5:
                scene = new StudyScene();
                break;

            case 6:
                scene = new FanLetterScene();
                break;

            case 7:
                //合戦の予定
                scene = new KassenScene();
                break;


        }
        scene.Start();

        SceneManager.instance.SetScene(scene);


    }

    public int GetPlotCount() { return plotCount; }

    public void AddPlotCount() { plotCount++; TestText.text = plotCount.ToString(); }

    public void StartPlotScene() 
    {
        PlotUIManager.instance.Open(plotDecided[plotCount]);
    }

    private void StartPlotDecided() 
    {
        List<List<string>> data = TextLoad.Load(FILE_NAME);

        for(int i=0;i< MAX_PLOT; i++) 
        {
            plotDecided.Add(new List<int>());
            for (int j=0;j< MAX_PLOT; j++) 
            {
                if (data[i][j] == string.Empty) break;
                plotDecided[i].Add(int.Parse(data[i][j]));
            }
        }

       
    }

}
