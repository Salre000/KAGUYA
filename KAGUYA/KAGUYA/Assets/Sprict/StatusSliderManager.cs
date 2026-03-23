using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusSliderManager : MonoBehaviour
{
    public static StatusSliderManager instance;

    [SerializeField] StatusSlider FR;
    [SerializeField] StatusSlider PS;
    [SerializeField] StatusSlider FU;
    public void Awake()
    {
        instance = this; 
    }

    public void ChangeStatusUI() 
    {
        ChangeFR();
        ChangePS();
        ChangeFU();
    }

    private void ChangeFR() 
    {
        Status status=StatusManager.instance.GetDummyStatus();
        FR.ChangeValue(status.goodFriends,status.goodFriendsRate);
    }
    private void ChangePS() 
    {
        Status status=StatusManager.instance.GetDummyStatus();
        PS.ChangeValue(status.playSkill, status.playSkillRate);
    }
    private void ChangeFU() 
    {
        Status status=StatusManager.instance.GetDummyStatus();
        FU.ChangeValue(status.fun, status.funRate);
    }


}
