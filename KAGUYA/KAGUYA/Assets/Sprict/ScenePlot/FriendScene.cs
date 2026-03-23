using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendScene : SceneBase
{

    public override void Interference(Status status)
    {
        status.HP -= HPDecrease;

        status.goodFriends += 2000;//AddStatus+(int)(AddStatus*((status.goodFriendsRate+100)/100f));

        StatusManager.instance.SetStatus(status);

    }

    public override void Start()
    {
        base.Start();

        Debug.Log("フレンドシーンを開始");

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
