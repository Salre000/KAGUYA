using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KASSEBSceneCanvas : SceneCanvas
{

    private readonly string ALLY_COLOR = "1f37b2";
    private readonly string ENEMI_COLOR = "c00e0e";

    /// <summary>
    /// 現在の力の割合のテキスト
    /// </summary>
    [SerializeField] TextMeshProUGUI powerText;
    /// <summary>
    /// 現在の力の割合のイメージのオブジェクト
    /// </summary>
    [SerializeField] RectTransform powerImage;

    [SerializeField] List<Button> Cards = new List<Button>();

    private int GoalValueText = 0;
    private int GoalEnemiValueText = 0;
    private float GoalValue = 0;

    private int nowValueText = 0;
    private int nowEnemiValueText = 0;
    private float nowValue = 0;

    [SerializeField] private TextMeshProUGUI turnText;


    public void Awake()
    {
        SetGoalValues(500, 0);
    }

    public void Start()
    {
        // 内部数値を見た目に反映する関数
        BattleManager.instance.SetSetBattlePower(SetGoalValues);

    }

    public void Update()
    {
        ChangeValue();

        if (Input.GetKeyDown(KeyCode.P)) SetGoalValues(GoalValueText, 1000);
    }

    public override void SceneStart()
    {
        base.SceneStart();
        gameObject.SetActive(true);

        Reroll();



    }

    public override void SceneEnd()
    {
        base.SceneEnd();


        gameObject.SetActive(false);
    }

    private void ChangeValue()
    {
        bool changeFlag = false;

        if (GoalValueText > nowValueText) { nowValueText++; changeFlag = true; }
        if (GoalEnemiValueText > nowEnemiValueText){nowEnemiValueText++; changeFlag = true;}

        if (GoalValue > nowValue) { nowValue += 1f; changeFlag = true; }
        if (GoalValue < nowValue) { nowValue -= 1f; changeFlag = true; }

        if (!changeFlag) return;

        SetPowerText(nowValueText, nowEnemiValueText);

        Vector3 pos = powerImage.localPosition;
        pos.x = nowValue;
        powerImage.localPosition = pos;

    }


    private void SetPowerText(int power, int enemiPower)
    {

        StringBuilder sb = new StringBuilder();
        sb.Clear();

        sb.Append("<color=#");
        sb.Append(ALLY_COLOR);
        sb.Append(">");
        sb.Append(power.ToString());
        sb.Append("</color>");

        sb.Append("<color=#");
        sb.Append(power < enemiPower ? ENEMI_COLOR : ALLY_COLOR);
        sb.Append(">");
        sb.Append(" / ");
        sb.Append("</color>");

        sb.Append("<color=#");
        sb.Append(ENEMI_COLOR);
        sb.Append(">");
        sb.Append(enemiPower.ToString());
        sb.Append("</color>");


        powerText.text = sb.ToString();



    }

    private void SetGoalValues(int power, int enemiPower)
    {
        nowEnemiValueText = GoalEnemiValueText;
        nowValueText = GoalValueText;

        nowValue = GoalValue;

        GoalValueText += power;
        GoalEnemiValueText += enemiPower;

        float MAX_SIZE = 1000;

        float reta = (float)GoalValueText / (float)(GoalValueText + GoalEnemiValueText);

        MAX_SIZE *= reta;

        GoalValue = (1000 - MAX_SIZE) * -1;


    }

    private void Reroll() 
    {

        for (int i = 0; i < Cards.Count; i++)
        {
            Cards[i].onClick.RemoveAllListeners();
        }

        SetHandCardAction();

        turnText.text="残り"+BattleManager.instance.GetRemainingTurn().ToString()+"ターン";

    }

    private void SetHandCardAction() 
    {
        for(int i=0; i < Cards.Count; i++) 
        {
            int cash = i;
            Cards[i].onClick.AddListener(()=>
            {
                BattleManager.instance.SetCardAction(cash);


                Reroll();

            });
        }


    }








}
