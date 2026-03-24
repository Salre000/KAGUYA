using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public static TextManager instance;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI TextText;
    [SerializeField] string textData;
    [SerializeField] string textDummyData;

    [Header("この数字はテキストの何番目かどうかを判断する"),SerializeField] int plotCount = 0;


    private float time = 0;

    private readonly float MAX_COUNT = 0.2f;

    private bool textFlag = false;  




    public void Awake()
    {
        instance = this;
    }

    public void Update()
    {
        if (!textFlag) return;

        CheckClick();

        time += Time.deltaTime;
        if (time < MAX_COUNT) return;
        time = 0;

        ChangeText();
    }


    public void TextStart() 
    {
        textFlag = true;
        textData = TextLoadManager.instance.GetText(plotCount);
    }

    private void ChangeText() 
    {
        if (textData == textDummyData) {return; }
        

        Nest();

    }
    // 次の文字を追加する関数
    private void Nest() 
    {
        textDummyData += textData[textDummyData.Length];

        TextText.text = textDummyData;
    }

    /// <summary>
    /// 文字列が全て埋まっている時は次の文字列に移行して違う時はすべて埋める
    /// </summary>
    private void NestString() 
    {
        if (textData == textDummyData) 
        {
            plotCount++;

            textDummyData=string.Empty;

            textData = TextLoadManager.instance.GetText(plotCount);

            if(textData==string.Empty)End();


        }
        else
        {
            textDummyData = textData;
            TextText.text = textDummyData;

        }
    }

    private void CheckClick() 
    {
        if (!Input.GetMouseButtonDown(0)) return;

        NestString();



    }


    private void End() 
    {
        textFlag = false;
        textDummyData = string.Empty;
        textData = string.Empty;
        plotCount = 0;

        SceneManager.instance.SceneEnd();

    }

}
