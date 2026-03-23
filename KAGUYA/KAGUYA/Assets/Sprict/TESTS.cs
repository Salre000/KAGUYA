using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTS : SceneBase
{

    public override void Interference(Status status)
    {

        status.HP += 30;

        Debug.Log("HPã¸");

        StatusManager.instance.SetStatus(status);


    }

    public override void Start()
    {
        base.Start();
        StatusManager.instance.SetStatus(new Status());

        Debug.Log("ƒV[ƒ“Ø‚è‘Ö‚¦");

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

        StatusManager.instance.StatusInterference(Interference);

        SceneManager.instance.SetScene(null);

        Debug.Log("I—¹");

    }


}
