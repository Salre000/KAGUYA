using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendScene : SceneBase
{
    protected string textFileName = "FriendsUpText";


    public override void Interference(Status status)
    {
        status.goodFriends += 2000;

        StatusManager.instance.SetStatus(status);

    }

    public override void Start()
    {
        base.Start();

        Debug.Log("フレンドシーンを開始");



        TextLoadManager.instance.Load(textFileName,0,()=> { TextManager.instance.TextStart(); });
        


    }

    public override void Update()
    {
        base.Update();

        if(Input.GetKeyDown(KeyCode.O)) StatusManager.instance.StatusInterference(Interference);



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
