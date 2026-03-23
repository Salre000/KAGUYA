using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StatusSlider : MonoBehaviour
{
    [SerializeField] Image value;
    [SerializeField] TextMeshProUGUI nowValue;
    [SerializeField] TextMeshProUGUI nowRate;
    [SerializeField] TextMeshProUGUI nowRank;
        

    /// <summary>
    /// UIの見た目を割合に応じて変える関数
    /// </summary>
    /// <param name="MAX"></param>
    /// <param name="noeValue"></param>
    public void ChangeValue(int noeValue,int rate) 
    {

        // 現在のランクだけの最大値
        float NowRankRate= StatusRank.GetRankMaxValue(noeValue)-(int)StatusRank.GetDownRank(noeValue);

        float nowRata = ((float)noeValue- (float)StatusRank.GetDownRank(noeValue)) / NowRankRate;

        nowRate.text = rate.ToString() + "%";

        nowValue.text = noeValue.ToString();

        //　テスト
        nowRank.text = StatusRank.GetRankText(noeValue);

        value.fillAmount = nowRata;

    }


}
