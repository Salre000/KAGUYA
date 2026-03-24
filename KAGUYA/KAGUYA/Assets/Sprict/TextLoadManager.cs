using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class TextLoadManager : MonoBehaviour
{
    public static TextLoadManager instance;

    /// <summary>
    /// 会話の際のテキストなどを順序道理に纏めるリスト
    /// </summary>
    List<TextClass> textList = new List<TextClass>();

    private　readonly int OFFSET_RATE = 2;


    public void Awake()
    {
        instance = this;
    }


    /// <summary>
    /// テキストに使用するファイルをロードして変数に格納する関数
    /// </summary>
    /// <param name="fileName"><ファイルの名前/param>
    /// <param name="offset"><ファイルないのいくつ目を使うかどうかの変数/param>
    public void Load(string fileName,int offset=0,System.Action action=null) 
    {

        List<List<string>> loadData = TextLoad.Load(fileName);

        for(int i=0;i< loadData.Count;i++) 
        {
            if (loadData[i][offset * OFFSET_RATE] == string.Empty) break;
            // 代入
            textList.Add(new TextClass(loadData[i][offset * OFFSET_RATE+1], loadData[i][offset * OFFSET_RATE]));

        }

        if (action != null) action();



    }

    /// <summary>
    /// ロードしていたデータを破棄する関数
    /// </summary>
    public void Lost() 
    {
        textList.Clear();
    }

    /// <summary>
    /// このファイル内のテキスト群の数を返す関数
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public int GetLoadDataCount(string fileName) 
    {

        TextAsset csvFile; // CSVファイル
        List<string[]> csvData = new List<string[]>(); // CSVファイルの中身を入れるリスト
        csvFile = Resources.Load(fileName) as TextAsset; // ResourcesにあるCSVファイルを格納
        StringReader reader = new StringReader(csvFile.text); // TextAssetをStringReaderに変換


        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine(); // 1行ずつ読み込む
            csvData.Add(line.Split(',')); // csvDataリストに追加する
        }

        return csvData.Count/ OFFSET_RATE;

    }

    public string GetText(int ID)
    {
        if(textList.Count<=ID)return string.Empty;


        return textList[ID].text;
    }
    public string GetName(int ID) { return textList[ID].name; }






    /// <summary>
    /// 会話パートで使用する物を纏めたクラス
    /// </summary>
    class TextClass 
    {
        public string text=string.Empty;
        public string name=string.Empty;
        public TextClass(string _name,string _text)
        {
            text = _text;
            name = _name;
        }
    }

}
