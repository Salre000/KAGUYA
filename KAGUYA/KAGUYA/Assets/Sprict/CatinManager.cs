using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatinManager : MonoBehaviour
{

    public static CatinManager instance;

    private readonly int START_RENGE = -1100;
    private readonly int MAX_RENGE = 2200;
    private readonly int OVERE_RENGE = 6000;

    public GameObject normalCutin;

    private System.Action cutinAction;

    public void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// 通常カットインを始める関数
    /// </summary>
    /// <param name="cutinAction"><この引数は完全に見えなくなった時に発生/param>
    public void StartNormalCutin(System.Action cutinAction = null)
    {
        this.cutinAction = cutinAction;

        normalCutin.SetActive(true);

    }


    public void Update()
    {
        if (!normalCutin.activeSelf) return;

        if (normalCutin.transform.localPosition.x < MAX_RENGE) return;

        if (cutinAction != null)
        {
            cutinAction();
            cutinAction = null;
        }

        if(normalCutin.transform.localPosition.x < OVERE_RENGE) return;

        Vector3 pos = normalCutin.transform.localPosition;

        pos.x = START_RENGE;

        normalCutin.transform.localPosition = pos;

        normalCutin.SetActive(false);



    }






}
