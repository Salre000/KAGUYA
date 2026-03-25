using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanLetterScene : SceneBase
{
    public override void Start()
    {
        base.Start();

        CatinManager.instance.StartNormalCutin();

    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.E))
        {
            End();
        }

    }
    public override void End()
    {
        base.End();


        SceneManager.instance.SetScene(null);

        Debug.Log("èIóπ");

    }


}
