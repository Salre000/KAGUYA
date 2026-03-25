using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatusSliderManager : MonoBehaviour
{
    public static StatusSliderManager instance;

    [SerializeField] StatusSlider FR;
    [SerializeField] StatusSlider PS;
    [SerializeField] StatusSlider FU;
    [SerializeField] RectTransform HPVar;
    [SerializeField] TextMeshProUGUI hpText;
    public void Awake()
    {
        instance = this;
    }

    public void ChangeStatusUI()
    {
        ChangeFR();
        ChangePS();
        ChangeFU();
        ChangeHP();
    }

    private void ChangeFR()
    {
        Status status = StatusManager.instance.GetDummyStatus();
        FR.ChangeValue(status.goodFriends, status.goodFriendsRate);
    }
    private void ChangePS()
    {
        Status status = StatusManager.instance.GetDummyStatus();
        PS.ChangeValue(status.playSkill, status.playSkillRate);
    }
    private void ChangeFU()
    {
        Status status = StatusManager.instance.GetDummyStatus();
        FU.ChangeValue(status.fun, status.funRate);
    }

    private void ChangeHP()
    {
        Status status = StatusManager.instance.GetDummyStatus();

        Vector3 hpPos = HPVar.localPosition;

        float HPrate = (float)status.HP / (float)status.MAX_HP;

        hpText.text = status.HP + " / " + status.MAX_HP;


        hpPos.x = -300 * (1-HPrate);

        HPVar.localPosition = hpPos;

    }

}
