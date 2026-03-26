using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderSceneCanvas : SceneCanvas
{

    /// <summary>
    /// ショップ内で購入可能なボタンリスト
    /// </summary>
    [SerializeField] List<Button> buttons = new List<Button>();

    /// <summary>
    /// 決定ボタン
    /// </summary>
    [SerializeField] Button selectButton;

    /// <summary>
    /// 終了ボタン
    /// </summary>
    [SerializeField] Button endButton;


    public void Awake()
    {
        selectButton.onClick.AddListener(() =>
        {

            SceneManager.instance.SceneEnd();

        });
    }

    public override void SceneStart()
    {
        base.SceneStart();
        gameObject.SetActive(true);




    }

    public override void SceneEnd()
    {
        base.SceneEnd();

        gameObject.SetActive(false);

        SceneManager.instance.SceneEnd();

    }

    /// <summary>
    ///  通販で得ることができる物を決定する関数
    /// </summary>
    private void SelectItem()
    {
        for (int i = 0; i < buttons.Count; i++)
        {

            buttons[i].onClick.AddListener(() =>
            {


            });

        }
    }

}
