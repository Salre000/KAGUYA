using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterSceneCanvas : SceneCanvas
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField]List<Button> buttons = new List<Button>();

    /// <summary>
    /// 決定ボタン
    /// </summary>
    [SerializeField] Button selectButton;

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

        for (int i = 0; i < buttons.Count; i++)
        {

            buttons[i].onClick.RemoveAllListeners();

        }


        gameObject.SetActive(false);
    }

    /// <summary>
    ///  ファンレターで得ることができる物を決定する関数
    /// </summary>
    private void SelectItem() 
    {
        for(int i=0;i< buttons.Count; i++) 
        {

            buttons[i].onClick.AddListener(() => 
            {


            });

        }
    }
}
