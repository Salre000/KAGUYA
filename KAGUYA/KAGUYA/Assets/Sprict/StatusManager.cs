using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour
{

    public static StatusManager instance;



    private Status status;
    private Status dummyStatus;

    private int FRN = 0;
    private int SPN = 0;
    private int FUN = 0;


    public void Awake()
    {
        instance = this;

    }

    public void Update()
    {


        if (!CheckDummyStatus()) return;

        SlowlyDummyStatusUp();

    }




    public Status GetStatus() { return status; }
    public Status GetDummyStatus() { return dummyStatus; }
    public void SetStatus(Status status) {this.status=status;}
    public void SetDummyStatus(Status status) { dummyStatus= status; }



    // ステータスに干渉する関数
    public void StatusInterference(System.Action<Status> action)
    {

        if(status!=null)dummyStatus= status.Cope();
        action(status);
    }
    /// <summary>
    ///  ダミーとの間に違いがあれば truee
    /// </summary>
    /// <returns></returns>
    public bool CheckDummyStatus() 
    {
        if(status==null)return false;
        if(dummyStatus==null)return false;

        if (status.goodFriends != dummyStatus.goodFriends) return true;
        if (status.playSkill != dummyStatus.playSkill) return true;
        if (status.fun != dummyStatus.fun) return true;

        if (status.goodFriendsRate != dummyStatus.goodFriendsRate) return true;
        if (status.playSkillRate != dummyStatus.playSkillRate) return true;
        if (status.funRate != dummyStatus.funRate) return true;

        if (status.HP != dummyStatus.HP) return true;
        if (status.LEEWAY_HP != dummyStatus.LEEWAY_HP) return true;
        if (status.fuju != dummyStatus.fuju) return true;

        return false;

    }

    /// <summary>
    /// ダミーステータスを本物のステータスにゆっくり近づける
    /// </summary>
    private void SlowlyDummyStatusUp() 
    {
        if (status.goodFriends > dummyStatus.goodFriends) dummyStatus.goodFriends++;
        if (status.playSkill > dummyStatus.playSkill) dummyStatus.playSkill++;
        if (status.fun > dummyStatus.fun) dummyStatus.fun++;
        if (status.HP > dummyStatus.HP) dummyStatus.HP++;
        else if (status.HP < dummyStatus.HP) dummyStatus.HP--;
        if (status.LEEWAY_HP > dummyStatus.LEEWAY_HP) dummyStatus.LEEWAY_HP++;
        else if (status.LEEWAY_HP < dummyStatus.LEEWAY_HP) dummyStatus.LEEWAY_HP--;


        StatusSliderManager.instance.ChangeStatusUI();



    }


}
