using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StatusUIManager : MonoBehaviour
{
    [SerializeField] Slider slider;

    [SerializeField]List<Slider> statusSliders = new List<Slider>();

    [SerializeField]TextMeshProUGUI textMeshProUGUI;

    public void Update()
    {
        Show();
    }
    private void Show() 
    {
        Status status = StatusManager.instance.GetStatus();
        if (status == null) return;

        slider.maxValue = status.MAX_HP;

        slider.value = status.HP;

        textMeshProUGUI.text = PlotManager.instance.GetPlotCount().ToString()+"ÉvÉçÉbÉgêî";

        ShowStatus(status);
    }

    private void ShowStatus(Status status) 
    {
        statusSliders[0].maxValue = 1000;
        statusSliders[0].value = status.goodFriends;
        statusSliders[1].maxValue = 1000;
        statusSliders[1].value = status.playSkill;
        statusSliders[2].maxValue = 1000;
        statusSliders[2].value = status.fun;



    }
}
