using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class TextLoad
{

    static public List<List<string>> Load(string flieName)
    {
        TextAsset csvFile; // CSVファイル
        List<string[]> csvData = new List<string[]>(); // CSVファイルの中身を入れるリスト
        csvFile = Resources.Load(flieName) as TextAsset; // ResourcesにあるCSVファイルを格納
        StringReader reader = new StringReader(csvFile.text); // TextAssetをStringReaderに変換

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine(); // 1行ずつ読み込む
            csvData.Add(line.Split(',')); // csvDataリストに追加する
        }

        List<List<string>> Data = new List<List<string>>();

        for (int i = 0; i < csvData.Count; i++)
        {
            Data.Add(new List<string>());

            for (int j = 0; j < csvData[i].Length; j++)
            {
                Data[i].Add(csvData[i][j]);
            }
        }
        return Data;
    }
}
