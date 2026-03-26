using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SceneCanvasManager;

public class FriendScene : SceneBase
{
    protected string textFileName = "FriendsUpText";


    public override void Interference(Status status)
    {
        status.goodFriends += 1;
        status.HP -= 1;

        StatusManager.instance.SetStatus(status);

    }

    public override void Start()
    {
        base.Start();

        Debug.Log("フレンドシーンを開始");


        CatinManager.instance.StartNormalCutin(() =>
        {
            TextLoadManager.instance.Load(textFileName, 0, () => { TextManager.instance.TextStart(); });

        });





    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.O)) StatusManager.instance.StatusInterference(Interference);



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
